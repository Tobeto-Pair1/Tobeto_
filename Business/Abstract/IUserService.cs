using Business.Dtos.Requests;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IUserService
{
    Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest);

    Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);

    Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest);


}
