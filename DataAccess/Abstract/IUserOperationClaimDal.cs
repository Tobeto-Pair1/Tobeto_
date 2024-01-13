using Core.DataAccess.Repositories;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserOperationClaimDal : IRepository<UserOperationClaim, int>, IAsyncRepository<UserOperationClaim, int>
{
}
