using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfEmployeeOperationClaimDal : EfRepositoryBase<EmployeeOperationClaim, Guid, TobetoDbContext>, IEmployeeOperationClaimDal
{
    public EfEmployeeOperationClaimDal(TobetoDbContext context) : base(context)
    {
    }
}
