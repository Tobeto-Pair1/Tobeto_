using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Business.DTOs.Users;
using Business.Rules;
using Core.Aspects.Autofac.Validation;
using Business.Validations;
using System.Net.Mail;
using MailKit.Security;
using MimeKit;
using ServiceStack.Messaging;
using Core.Utilities.Business.EmailService;

using Entities.Concretes;
using Core.CrossCuttingConcerns.Logger.Serilog.Loggers;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Business.Concrete;


public class AuthManager : IAuthService
{
    private readonly IUserService _userService;

    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IEmailService _emailService;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService, IMapper mapper, AuthBusinessRules authBusinessRules, IEmailService emailService)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;
        _mapper = mapper;
        _authBusinessRules = authBusinessRules;
        _emailService = emailService;
    }

    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(UserForRegisterRequestValidator))]
    public async Task<AccessToken> Register(UserForRegisterRequest userForRegisterRequest, string password)
    {
        await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(userForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        UserAuth userAuth = _mapper.Map<UserAuth>(userForRegisterRequest);
        userAuth.PasswordHash = passwordHash;
        userAuth.PasswordSalt = passwordSalt;
        var createdUser = await _userService.Add(userAuth);

        var resultToken = await CreateAccessToken(createdUser);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(resultToken);


        sendTestEmail(userForRegisterRequest);

       

        return resultToken;
    }


    public void sendTestEmail(UserForRegisterRequest userForRegisterRequest)
    {
        string message = $@"<p>Test Mail Sent";
        _emailService.Send(to: userForRegisterRequest.Email, subject: "Deneme",
            html: $@"<h4> Verify Email</h4>
                        <p>Thanks for testing</p> {message}");
    }






    public async Task<AccessToken> Login(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _authBusinessRules.LoginInformationCheck(userForLoginRequest);


        var result = await CreateAccessToken(userToCheck);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }

    public async Task<AccessToken> CreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }
}
