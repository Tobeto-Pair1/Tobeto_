using Core.DataAccess.Repositories;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserOperationClaimDal : IRepository<UserOperationClaim, Guid>, IAsyncRepository<UserOperationClaim, Guid>
{
}
