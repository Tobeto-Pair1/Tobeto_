using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
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
    Task<UserAuth> Add(UserAuth userAuth);
    Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);
    //Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest);
    Task<DeletedUserResponse> Delete(Guid id);

    Task<UserAuth> GetByMail(string email);

}
