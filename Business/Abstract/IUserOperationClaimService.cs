using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Business.Dtos.UserOperationClaims;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
    Task<IPaginate<GetListUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedUserOperationClaimResponse> Add(CreateUserOperationClaimRequest createUserOperationClaimRequest);
    Task<DeletedUserOperationClaimResponse> Delete(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest);
    Task<UpdatedUserOperationClaimResponse> Update(UpdateUserOperationClaimRequest updateUserOperationClaimRequest);
    Task<IList<OperationClaim>> GetClaims(Guid id);
}
