using AutoMapper;
using Business.Abstract;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business.DTOs.UserSocials;

namespace Business.Concrete
{
    public class UserSocialManager : IUserSocialService
    {
        IUserSocialDal _userSocialDal;
        IMapper _mapper;

        public UserSocialManager(IUserSocialDal userSocialDal, IMapper mapper)
        {
            _userSocialDal = userSocialDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserSocialResponse> Add(CreateUserSocialRequest createUserSocialRequest)
        {
            UserSocial userSocial = _mapper.Map<UserSocial>(createUserSocialRequest);
            UserSocial createdUserSocial = await _userSocialDal.AddAsync(userSocial);
            CreatedUserSocialResponse createdUserSocialResponse = _mapper.Map<CreatedUserSocialResponse>(createdUserSocial);
            return createdUserSocialResponse;
        }

        public async Task<DeletedUserSocialResponse> Delete(DeleteUserSocialRequest deleteUserSocialRequest)
        {
            UserSocial userSocial = _mapper.Map<UserSocial>(deleteUserSocialRequest);
            UserSocial deletedUserSocial = await _userSocialDal.DeleteAsync(userSocial);
            DeletedUserSocialResponse deletedUserSocialResponse = _mapper.Map<DeletedUserSocialResponse>(deletedUserSocial);
            return deletedUserSocialResponse;
        }

        public async Task<IPaginate<GetListUserSocialResponse>> GetListAsync(PageRequest pageRequest)
        {

            var data = await _userSocialDal.GetListAsync(include: a => a.Include(a => a.SocialMedia).
            Include(a => a.User),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListUserSocialResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserSocialResponse> Update(UpdateUserSocialRequest updateUserSocialRequest)
        {
            UserSocial userSocial = _mapper.Map<UserSocial>(updateUserSocialRequest);
            UserSocial updatedUserSocial = await _userSocialDal.UpdateAsync(userSocial);
            UpdatedUserSocialResponse updatedUserSocialResponse = _mapper.Map<UpdatedUserSocialResponse>(updatedUserSocial);
            return updatedUserSocialResponse;
        }
    }
}
