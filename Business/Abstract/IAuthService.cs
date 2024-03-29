using Business.Dtos.RefreshTokens;
using Business.DTOs.Auths;
using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IAuthService
{
    Task<RefreshTokenResponse> Register(UserForRegisterRequest userForRegisterRequest, string password, string IpAddress);
    Task<RefreshTokenResponse> Login(UserForLoginRequest userForLoginRequest, string IpAddress);
    Task<RefreshTokenResponse> TokenAdded(UserAuth createdUser, string IpAddress);
    Task PasswordReset(PasswordResetRequest passwordResetRequest);
    Task<bool> VerifyResetTokenAsync(VerifyResetTokenRequest verifyResetTokenRequest);
}
