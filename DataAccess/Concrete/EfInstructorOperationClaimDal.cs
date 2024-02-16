using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfInstructorOperationClaimDal : EfRepositoryBase<InstructorOperationClaim, Guid, TobetoDbContext>, IInstructorOperationClaimDal
{
    public EfInstructorOperationClaimDal(TobetoDbContext context) : base(context)
    {
    }
}