using AutoMapper;
using Business.Abstract;
using Business.Dtos.ResetTokens;
using Business.Rules;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;

namespace Business.Concrete;

public class ResetTokenManager : IResetTokenService
{
    private readonly IResetTokenDal _resetTokenDal;
    private readonly ResetTokenBusinessRules _resetTokenBusinessRules;
    private readonly IMapper _mapper;

    public ResetTokenManager(ResetTokenBusinessRules resetTokenBusinessRules,
        IMapper mapper, IResetTokenDal resetTokenDal)
    {
;
        _resetTokenBusinessRules = resetTokenBusinessRules;
        _mapper = mapper;
        _resetTokenDal = resetTokenDal;
    }


    public async Task<RevokedTokenResponse> RevokedToken(string Token)
    {
        ResetToken? resetToken = await GetResetTokenByToken(Token);
        await _resetTokenBusinessRules.ResetTokenShouldBeExists(resetToken);
        await _resetTokenBusinessRules.ResetTokenShouldBeActive(resetToken!);

        await RevokeResetToken(resetToken!);

        RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(resetToken);
        return revokedTokenResponse;
    }
    public async Task<ResetToken?> GetResetTokenByToken(string token)
    {
        ResetToken? resetToken = await _resetTokenDal.GetAsync(predicate: r => r.Token == token);
        return resetToken;
    }

    public async Task RevokeResetToken(ResetToken resetToken)
    {
        resetToken.Revoked = DateTime.UtcNow;
        await _resetTokenDal.UpdateAsync(resetToken);

    }
}
