using AutoMapper;
using Business.Abstract;
using Business.Dtos.UserOperationClaims;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimDal _userOperationClaimDal;
    private readonly IMapper _mapper;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
    {
        _userOperationClaimDal = userOperationClaimDal;
        _mapper = mapper;
    }
    public async Task<CreatedUserOperationClaimResponse> Add(CreateUserOperationClaimRequest createUserOperationClaimRequest)
    {
        UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(createUserOperationClaimRequest);
        UserOperationClaim createdUserOperationClaim = await _userOperationClaimDal.AddAsync(userOperationClaim);
        CreatedUserOperationClaimResponse createdUserOperationClaimResponse = _mapper.Map<CreatedUserOperationClaimResponse>(createdUserOperationClaim);
        return createdUserOperationClaimResponse;
    }

    public async Task<DeletedUserOperationClaimResponse> Delete(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
    {
        UserOperationClaim? userOperation = await _userOperationClaimDal.GetAsync(p => p.Id == deleteUserOperationClaimRequest.Id);
        await _userOperationClaimDal.DeleteAsync(userOperation);
        DeletedUserOperationClaimResponse deletedUserOperationClaimResponse = _mapper.Map<DeletedUserOperationClaimResponse>(userOperation);
        return deletedUserOperationClaimResponse;
    }

    public async Task<IPaginate<GetListUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userOperationClaimDal.GetListAsync(
            include: p => p.Include(p => p.OperationClaim),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var result = _mapper.Map<Paginate<GetListUserOperationClaimResponse>>(data);
        return result;
    }
    public async Task<UpdatedUserOperationClaimResponse> Update(UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
    {
        UserOperationClaim UserOperationClaim = await _userOperationClaimDal.GetAsync(u => u.Id == updateUserOperationClaimRequest.Id);
        _mapper.Map(updateUserOperationClaimRequest, UserOperationClaim);
        UserOperationClaim updatedUserOperationClaim = await _userOperationClaimDal.UpdateAsync(UserOperationClaim);
        UpdatedUserOperationClaimResponse updatedUserOperationClaimResponse = _mapper.Map<UpdatedUserOperationClaimResponse>(updatedUserOperationClaim);
        return updatedUserOperationClaimResponse;
    }
    public async Task<IList<OperationClaim>> GetClaims(Guid id)
    {
        var userOperationClaims = await _userOperationClaimDal.GetListAsync(u => u.UserId == id,
                                                               include: u => u.Include(u => u.OperationClaim));
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
            { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
        return operationClaims;
    }
}
