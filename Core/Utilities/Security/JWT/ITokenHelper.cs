using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    //ilgili kullanıcı için claim varsa token oluşturur
    Task<AccessToken> CreateToken(UserAuth user, IList<OperationClaim> operationClaims);
    RefreshToken CreateRefreshToken(UserAuth userAuth, string ipAddress);
}
