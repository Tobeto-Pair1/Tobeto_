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
    public interface IUserSkillService
    {
        Task<IPaginate<GetListUserSkillResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedUserSkillResponse> Add(CreateUserSkillRequest createUserSkillRequest);

        Task<UpdatedUserSkillResponse> Update(UpdateUserSkillRequest updateUserSkillRequest);

        Task<DeletedUserSkillResponse> Delete(DeleteUserSkillRequest deleteUserSkillRequest);
    }
}
