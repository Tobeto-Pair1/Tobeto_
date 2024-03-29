using AutoMapper;
using Business.Abstract;
using Business.Dtos.RefreshTokens;
using Business.Rules;
using Business.Services.Tokens;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;

namespace Business.Concrete;

public class RefreshTokenManager : IRefreshTokenService
{
    private readonly IRefreshTokenDal _refreshTokenDal;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules;
    private readonly IMapper _mapper;

    public RefreshTokenManager(IUserService userService, ITokenService tokenService, RefreshTokenBusinessRules refreshTokenBusinessRules,
        IMapper mapper, IRefreshTokenDal refreshTokenDal)
    {
        _userService = userService;
        _tokenService = tokenService;
        _refreshTokenBusinessRules = refreshTokenBusinessRules;
        _mapper = mapper;
        _refreshTokenDal = refreshTokenDal;
    }

    public async Task<RefreshTokenResponse> RefreshAccessToken(string RefreshToken, string IpAddress)
    {
        var refreshToken = await GetRefreshTokenByToken(RefreshToken);
        await _refreshTokenBusinessRules.RefreshTokenMustExist(refreshToken);

        if (refreshToken!.Revoked != null)
            await RevokeDescendantRefreshTokens(refreshToken, IpAddress, reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");

        await _refreshTokenBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        var user = await _userService.GetById(refreshToken.UserId);
        await _refreshTokenBusinessRules.UserShouldBeExistsWhenSelected(user);

        RefreshToken newRefreshToken = await RotateRefreshToken(user: user!, refreshToken, IpAddress);
        RefreshToken addedRefreshToken = await _tokenService.AddRefreshToken(newRefreshToken);
        await _tokenService.DeleteOldRefreshTokens(refreshToken.UserId);

        AccessToken createdAccessToken = await _tokenService.CreateAccessToken(user!);

        RefreshTokenResponse refreshedTokensResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return refreshedTokensResponse;
    }


    public async Task<RevokedTokenResponse> RevokedToken(string Token, string IPAddress)
    {
        RefreshToken? refreshToken = await GetRefreshTokenByToken(Token);
        await _refreshTokenBusinessRules.RefreshTokenShouldBeExists(refreshToken);
        await _refreshTokenBusinessRules.RefreshTokenShouldBeActive(refreshToken!);

        await RevokeRefreshToken(refreshToken!, IPAddress, reason: "Revoked without replacement");

        RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(refreshToken);
        return revokedTokenResponse;
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
        RefreshToken newRefreshToken = await _tokenService.CreateRefreshToken(user, ipAddress);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }
}
