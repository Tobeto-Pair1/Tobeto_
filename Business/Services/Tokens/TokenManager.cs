using AutoMapper;
using Business.Abstract;
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
    private readonly IResetTokenDal _resetTokenDal;
    private readonly TokenOptions _tokenOptions;


    public TokenManager(IRefreshTokenDal refreshTokenDal, ITokenHelper tokenHelper, IConfiguration configuration, IUserOperationClaimService userOperationClaimService, IResetTokenDal resetTokenDal)
    {
        _refreshTokenDal = refreshTokenDal;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;

        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
        _resetTokenDal = resetTokenDal;
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
    public async Task<ResetToken> AddResetToken(ResetToken resetToken)
    {

        ResetToken addedResetToken = await _resetTokenDal.AddAsync(resetToken);
        return addedResetToken;
    }

    public async Task<ResetToken> CreateResetToken(UserAuth userAuth)
    {
        ResetToken resetToken = _tokenHelper.CreateResetToken(userAuth);
        return await Task.FromResult(resetToken);
    }
    public async Task<ResetToken?> GetResetTokenByToken(string token)
    {
        ResetToken? resetToken = await _resetTokenDal.GetAsync(predicate: r => r.Token == token);
        return resetToken;
    }
}
