using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete;

public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, int, TobetoDbContext>, IUserOperationClaimDal
{
    public EfUserOperationClaimDal(TobetoDbContext context) : base(context)
    {
    }
}
