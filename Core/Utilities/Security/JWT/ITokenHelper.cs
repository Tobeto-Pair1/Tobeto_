using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(UserAuth user, IList<OperationClaim> operationClaims);
    RefreshToken CreateRefreshToken(UserAuth userAuth, string ipAddress);
    ResetToken CreateResetToken(UserAuth userAuth);
}
