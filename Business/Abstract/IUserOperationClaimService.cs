using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Business.DTOs.Users;
using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
   Task<IList<OperationClaim>> GetClaims(Guid id);

}