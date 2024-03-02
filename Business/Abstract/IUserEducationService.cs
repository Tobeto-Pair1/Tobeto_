using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.UserEducations;

namespace Business.Abstract;

public interface IUserEducationService
{
    Task<IPaginate<GetListUserEducationResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedUserEducationResponse> Add(CreateUserEducationRequest createUserEducationRequest);

    Task<UpdatedUserEducationResponse> Update(UpdateUserEducationRequest updateUserEducationRequest);

    Task<DeletedUserEducationResponse> Delete(DeleteUserEducationRequest deleteUserEducationRequest);
    Task<IPaginate<GetListUserEducationResponse>> GetListByUser(Guid userId);
}
