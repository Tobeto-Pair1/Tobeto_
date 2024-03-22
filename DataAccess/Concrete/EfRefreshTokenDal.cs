using Core.DataAccess.Repositories;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete;

public class EfRefreshTokenDal : EfRepositoryBase<RefreshToken, Guid, TobetoDbContext>, IRefreshTokenDal
{
    public EfRefreshTokenDal(TobetoDbContext context) : base(context)
    {
    }
}
