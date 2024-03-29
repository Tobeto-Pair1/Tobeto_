using Business.Dtos.ResetTokens;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IResetTokenService
{
    Task<ResetToken?> GetResetTokenByToken(string token);
    Task<RevokedTokenResponse> RevokedToken(string Token);
}
