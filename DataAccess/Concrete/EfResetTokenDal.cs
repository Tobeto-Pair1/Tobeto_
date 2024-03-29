using Core.DataAccess.Repositories;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete;

public class EfResetTokenDal : EfRepositoryBase<ResetToken, Guid, TobetoDbContext>, IResetTokenDal
{
    public EfResetTokenDal(TobetoDbContext context) : base(context)
    {
    }
}
