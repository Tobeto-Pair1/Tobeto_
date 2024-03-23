using Business.Dtos.RefreshTokens;
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
    Task<GetListUserResponse> GetListById(Guid id);
    Task<UserAuth> Add(UserAuth userAuth);
    Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);
    Task<UserAuth> GetById(Guid id);
    Task<DeletedUserResponse> Delete(Guid id);

    Task<UserAuth> GetByMail(string email);
    Task<RefreshTokenResponse> UpdatePassword(UpdatePasswordRequest updatePasswordRequest, string IpAddress );

}
