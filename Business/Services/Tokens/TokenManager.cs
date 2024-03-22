using AutoMapper;
using Business.Abstract;
using Business.Rules;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Business.Services.Tokens;

public class TokenManager : ITokenService
{
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenDal _refreshTokenDal;
    private readonly TokenOptions _tokenOptions;


    public TokenManager(IRefreshTokenDal refreshTokenDal, ITokenHelper tokenHelper, IConfiguration configuration, IUserOperationClaimService userOperationClaimService)
    {
        _refreshTokenDal = refreshTokenDal;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;

        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
    }
    public async Task<RefreshToken> CreateRefreshToken(UserAuth userAuth, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(userAuth, ipAddress);
        return await Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenDal.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> CreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }

    public async Task DeleteOldRefreshTokens(Guid userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenDal.Query().AsNoTracking()
            .Where(
                r =>
                    r.UserId == userId
                    && r.Revoked == null
                && r.Expires >= DateTime.UtcNow
                    && r.CreatedDate.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow
            )
            .ToListAsync();

        await _refreshTokenDal.DeleteRangeAsync(refreshTokens);
    }
    public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenDal.GetAsync(predicate: r => r.Token == token);
        return refreshToken;
    }
    public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await _refreshTokenDal.GetAsync(predicate: r => r.Token == refreshToken.ReplacedByToken);

        if (childToken?.Revoked != null && childToken.Expires <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(refreshToken: childToken!, ipAddress, reason);
    }
    public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        refreshToken.Revoked = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await _refreshTokenDal.UpdateAsync(refreshToken);

    }
    public async Task<RefreshToken> RotateRefreshToken(UserAuth user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = await CreateRefreshToken(user, ipAddress);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }
}
