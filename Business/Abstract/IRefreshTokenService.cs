using Business.Dtos.RefreshTokens;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IRefreshTokenService
{
    Task<RefreshTokenResponse> RefreshAccessToken(string RefreshToken, string IPAddress);
    Task<RevokedTokenResponse> RevokedToken(string RefreshToken, string IPAddress);
    public Task<RefreshToken?> GetRefreshTokenByToken(string token);
    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);
    public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null);
    public Task<RefreshToken> RotateRefreshToken(UserAuth user, RefreshToken refreshToken, string ipAddress);
}
