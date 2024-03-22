using Core.DataAccess.Repositories;
using Core.Utilities.Security.JWT;

namespace DataAccess.Abstract;

public interface IRefreshTokenDal : IRepository<RefreshToken, Guid>, IAsyncRepository<RefreshToken, Guid>
{
}
