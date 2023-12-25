using Business.DTOs.UserSocials;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserSocialService
    {
        Task<IPaginate<GetListUserSocialResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedUserSocialResponse> Add(CreateUserSocialRequest createUserSocialRequest);

        Task<UpdatedUserSocialResponse> Update(UpdateUserSocialRequest updateUserSocialRequest);

        Task<DeletedUserSocialResponse> Delete(DeleteUserSocialRequest deleteUserSocialRequest);
    }
}
