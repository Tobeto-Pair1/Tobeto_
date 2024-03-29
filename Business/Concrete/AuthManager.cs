using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Business.DTOs.Users;
using Business.Rules;
using Core.Aspects.Autofac.Validation;
using Business.Validations;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.EmailSender;
using Business.Dtos.RefreshTokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using Business.Services.Tokens;

namespace Business.Concrete;


public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public AuthManager(IUserService userService, IMapper mapper, AuthBusinessRules authBusinessRules, IEmailService emailService, IConfiguration configuration, ITokenService tokenService)
    {
        _userService = userService;
        _mapper = mapper;
        _authBusinessRules = authBusinessRules;
        _emailService = emailService;
        _configuration = configuration;
        _tokenService = tokenService;
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

        //var createdAccessToken = await _refreshTokenService.CreateAccessToken(createdUser);
        //RefreshToken createdRefreshToken = await _refreshTokenService.CreateRefreshToken(createdUser, IpAddress);
        //RefreshToken addedRefreshToken = await _refreshTokenService.AddRefreshToken(createdRefreshToken);

        //RefreshTokenResponse registeredDto = new()
        //{
        //    RefreshToken = addedRefreshToken,
        //    AccessToken = createdAccessToken,
        //};
        //await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(registeredDto);


        sendRegisterEmail(userForRegisterRequest);  

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


    public void sendRegisterEmail(UserForRegisterRequest userForRegisterRequest)
    {
        string message = $@"<p>Tobeto'ya Hoşgeldin!</p>";
        string htmlBody = $@"<h4>E-posta Adresinizi Doğrulayın</h4> {message}";
        _emailService.Send(to: userForRegisterRequest.Email, subject: "Kaydınızı Onaylayın",
            html: htmlBody);
    }

    public async Task<RefreshTokenResponse> Login(UserForLoginRequest userForLoginRequest, string IpAddress)
    {
        var userToCheck = await _authBusinessRules.LoginInformationCheck(userForLoginRequest);

        var createdAccessToken = await _tokenService.CreateAccessToken(userToCheck);
        RefreshToken createdRefreshToken = await _tokenService.CreateRefreshToken(userToCheck, IpAddress);
        await _tokenService.AddRefreshToken(createdRefreshToken);
        await _tokenService.DeleteOldRefreshTokens(userToCheck.Id);

        RefreshTokenResponse registeredDto = new()
        {
            RefreshToken = createdRefreshToken,
            AccessToken = createdAccessToken,
        };
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(registeredDto);
        return registeredDto;
    }


    //public async Task PasswordReset(string email)
    //{
    //    var user = await _authBusinessRules.UserWithSameEmailShouldExist(email);
    //    ResetToken createdResetToken = await _tokenService.CreateResetToken(user);
    //    await _tokenService.AddResetToken(createdResetToken);


    //    SendPasswordResetMailAsync(email, createdResetToken.Token);
    //}
    //public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
    //{
        
    //    if (user != null)
    //    {
    //        //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
    //        //resetToken = Encoding.UTF8.GetString(tokenBytes);
    //        resetToken = resetToken.UrlDecode();

    //        return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
    //    }
    //    return false;
    //}
    public void SendPasswordResetMailAsync(string email, string resetToken)
    {
        StringBuilder mail = new();
        mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
        mail.AppendLine(_configuration["AngularClientUrl"]);
        mail.AppendLine("/update-password/");
        mail.AppendLine("/");
        mail.AppendLine(resetToken);
        mail.AppendLine("\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">" +
            "NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...<br><br><br>NG - Mini|E-Ticaret");
        
       // string message = $@"<p>Test Mail Sent";
        _emailService.Send(to: email, subject: "Şifre Yenileme Talebi", html: mail.ToString());
    }  
}
