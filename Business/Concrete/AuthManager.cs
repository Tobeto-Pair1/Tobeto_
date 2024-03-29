using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Business.Rules;
using Core.Aspects.Autofac.Validation;
using Business.Validations;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Business.Dtos.RefreshTokens;
using Business.Services.Tokens;
using Core.Utilities.Security.Encryption;
using Business.DTOs.Auths;
using Business.Messages;

namespace Business.Concrete;


public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly ResetTokenBusinessRules _resetTokenBusinessRules;
    private readonly IMailMessages _mailMessages;

    public AuthManager(IUserService userService, IMapper mapper, AuthBusinessRules authBusinessRules, ITokenService tokenService, IMailMessages mailMessages, ResetTokenBusinessRules resetTokenBusinessRules)
    {
        _userService = userService;
        _mapper = mapper;
        _authBusinessRules = authBusinessRules;
        _tokenService = tokenService;
        _mailMessages = mailMessages;
        _resetTokenBusinessRules = resetTokenBusinessRules;
    }

    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(UserForRegisterRequestValidator))]
    public async Task<RefreshTokenResponse> Register(UserForRegisterRequest userForRegisterRequest, string password, string IpAddress)
    {
        await _authBusinessRules.UserWithSameEmailShouldNotExist(userForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        UserAuth userAuth = _mapper.Map<UserAuth>(userForRegisterRequest);
        userAuth.PasswordHash = passwordHash;
        userAuth.PasswordSalt = passwordSalt;
        var createdUser = await _userService.Add(userAuth);


        RefreshTokenResponse registeredDto = await TokenAdded(createdUser, IpAddress);

        _mailMessages.sendRegisterEmail(userForRegisterRequest);

        return registeredDto;
    }

    public async Task<RefreshTokenResponse> Login(UserForLoginRequest userForLoginRequest, string IpAddress)
    {
        var userToCheck = await _authBusinessRules.LoginInformationCheck(userForLoginRequest);

        RefreshTokenResponse registeredDto = await TokenAdded(userToCheck, IpAddress);

        await _tokenService.DeleteOldRefreshTokens(userToCheck.Id);

        return registeredDto;
    }
    public async Task<RefreshTokenResponse> TokenAdded(UserAuth createdUser, string IpAddress)
    {
        var createdAccessToken = await _tokenService.CreateAccessToken(createdUser);
        RefreshToken createdRefreshToken = await _tokenService.CreateRefreshToken(createdUser, IpAddress);
        RefreshToken addedRefreshToken = await _tokenService.AddRefreshToken(createdRefreshToken);

        RefreshTokenResponse registeredDto = new()
        {
            RefreshToken = addedRefreshToken,
            AccessToken = createdAccessToken,
        };
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(registeredDto);
        return registeredDto;
    }


    public async Task PasswordReset(PasswordResetRequest passwordResetRequest)
    {
        var user = await _authBusinessRules.UserWithSameEmailShouldExist(passwordResetRequest.Email);
        ResetToken resetToken = await _tokenService.CreateResetToken(user);
        await _tokenService.AddResetToken(resetToken);

        resetToken.Token = CustomEncoders.UrlEncode(resetToken.Token);

        _mailMessages.SendPasswordResetMailAsync(passwordResetRequest.Email, user.Id.ToString(), resetToken.Token);
    }
    public async Task<bool> VerifyResetTokenAsync(VerifyResetTokenRequest verifyResetTokenRequest)
    {
        await _authBusinessRules.UserWithSameIdShouldExist(verifyResetTokenRequest.UserId);

        verifyResetTokenRequest.ResetToken = CustomEncoders.UrlDecode(verifyResetTokenRequest.ResetToken);
        var token = await _tokenService.GetResetTokenByToken(verifyResetTokenRequest.ResetToken);
        await _resetTokenBusinessRules.ResetTokenShouldBeExists(token);
        await _resetTokenBusinessRules.ResetTokenShouldBeActive(token!);
        if (token.UserId == verifyResetTokenRequest.UserId)
        {
            return true;
        }

        return false;
    }
}
