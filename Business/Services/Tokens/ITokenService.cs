using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Services.Tokens;

public interface ITokenService
{
    Task<AccessToken> CreateAccessToken(UserAuth userAuth);
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> CreateRefreshToken(UserAuth userAuth, string ipAddress);
    public Task<RefreshToken?> GetRefreshTokenByToken(string token);
    public Task DeleteOldRefreshTokens(Guid userId);
    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);
    public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null);
    public Task<RefreshToken> RotateRefreshToken(UserAuth user, RefreshToken refreshToken, string ipAddress);
}
