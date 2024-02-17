using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IEmployeeOperationClaimDal : IRepository<EmployeeOperationClaim, Guid>, IAsyncRepository<EmployeeOperationClaim, Guid>
{
}
