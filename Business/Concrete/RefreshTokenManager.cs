using AutoMapper;
using Business.Abstract;
using Business.Dtos.RefreshTokens;
using Business.Rules;
using Business.Services.Tokens;
using Core.Utilities.Security.JWT;

namespace Business.Concrete;

public class RefreshTokenManager : IRefreshTokenService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules;
    private readonly IMapper _mapper;

    public RefreshTokenManager(IUserService userService, ITokenService tokenService, RefreshTokenBusinessRules refreshTokenBusinessRules, IMapper mapper)
    {
        _userService = userService;
        _tokenService = tokenService;
        _refreshTokenBusinessRules = refreshTokenBusinessRules;
        _mapper = mapper;
    }

    public async Task<RefreshTokenResponse> RefreshAccessToken(string RefreshToken, string IpAddress)
    {
        var refreshToken = await _tokenService.GetRefreshTokenByToken(RefreshToken);
        await _refreshTokenBusinessRules.RefreshTokenMustExist(refreshToken);

        if (refreshToken!.Revoked != null)
            await _tokenService.RevokeDescendantRefreshTokens(refreshToken, IpAddress, reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");

        await _refreshTokenBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        var user = await _userService.GetById(refreshToken.UserId);
        await _refreshTokenBusinessRules.UserShouldBeExistsWhenSelected(user);

        RefreshToken newRefreshToken = await _tokenService.RotateRefreshToken(user: user!, refreshToken, IpAddress);
        RefreshToken addedRefreshToken = await _tokenService.AddRefreshToken(newRefreshToken);
        await _tokenService.DeleteOldRefreshTokens(refreshToken.UserId);

        AccessToken createdAccessToken = await _tokenService.CreateAccessToken(user!);

        RefreshTokenResponse refreshedTokensResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return refreshedTokensResponse;
    }


    public async Task<RevokedTokenResponse> RevokedToken(string Token, string IPAddress)
    {
        RefreshToken? refreshToken = await _tokenService.GetRefreshTokenByToken(Token);
        await _refreshTokenBusinessRules.RefreshTokenShouldBeExists(refreshToken);
        await _refreshTokenBusinessRules.RefreshTokenShouldBeActive(refreshToken!);

        await _tokenService.RevokeRefreshToken(refreshToken!, IPAddress, reason: "Revoked without replacement");

        RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(refreshToken);
        return revokedTokenResponse;
    }
}
