using Business.DTOs.UserLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserLanguageService
    {
        Task<IPaginate<GetListUserLanguageResponse>> GetListAsync(PageRequest pageRequest);
        Task<IPaginate<GetListUserLanguageResponse>> GetListByUser(Guid UserId);

        Task<CreatedUserLanguageResponse> Add(CreateUserLanguageRequest createUserLanguageRequest);

        Task<UpdatedUserLanguageResponse> Update(UpdateUserLanguageRequest updateUserLanguageRequest);

        Task<DeletedUserLanguageResponse> Delete(DeleteUserLanguageRequest deleteUserLanguageRequest);
    }
}
