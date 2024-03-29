using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Services.Tokens;

public interface ITokenService
{
    Task<AccessToken> CreateAccessToken(UserAuth userAuth);
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> CreateRefreshToken(UserAuth userAuth, string ipAddress);
    Task DeleteOldRefreshTokens(Guid userId);

    Task<ResetToken> AddResetToken(ResetToken resetToken);
    Task<ResetToken> CreateResetToken(UserAuth userAuth);
    Task<ResetToken?> GetResetTokenByToken(string token);
}
