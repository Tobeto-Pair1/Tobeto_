using Business.DTOs.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
