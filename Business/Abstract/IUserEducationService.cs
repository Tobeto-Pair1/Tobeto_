using System;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract
{
	public interface IUserEducationService
	{
        Task<IPaginate<GetListUserEducationResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserEducationResponse> Add(CreateUserEducationRequest createUserEducationRequest);

        Task<UpdatedUserEducationResponse> Update(UpdateUserEducationRequest updateUserEducationRequest);

        Task<DeletedUserEducationResponse> Delete(DeleteUserEducationRequest deleteUserEducationRequest);
    }
}

