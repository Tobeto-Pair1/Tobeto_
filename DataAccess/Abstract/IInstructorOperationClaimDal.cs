using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IInstructorOperationClaimDal : IRepository<InstructorOperationClaim, Guid>, IAsyncRepository<InstructorOperationClaim, Guid>
{
}