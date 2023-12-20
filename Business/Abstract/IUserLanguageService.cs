using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
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
    public interface IUserLanguageService
    {
        Task<IPaginate<GetListUserLanguageResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserLanguageResponse> Add(CreateUserLanguageRequest createUserLanguageRequest);

        Task<UpdatedUserLanguageResponse> Update(UpdateUserLanguageRequest updateUserLanguageRequest);

        Task<DeletedUserLanguageResponse> Delete(DeleteUserLanguageRequest deleteUserLanguageRequest);
    }
}
