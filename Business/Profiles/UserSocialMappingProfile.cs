using AutoMapper;
using Business.DTOs.UserSocials;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserSocialMappingProfile: Profile
    {
        public UserSocialMappingProfile()
        {
            CreateMap<UserSocial, CreatedUserSocialResponse>().ReverseMap();
            CreateMap<CreateUserSocialRequest, UserSocial>().ReverseMap();

            CreateMap<UserSocial, DeletedUserSocialResponse>().ReverseMap();
            CreateMap<DeleteUserSocialRequest, UserSocial>().ReverseMap();

            CreateMap<UserSocial, UpdatedUserSocialResponse>().ReverseMap();
            CreateMap<UpdateUserSocialRequest, UserSocial>().ReverseMap();

            CreateMap<User, GetListUserSocialResponse>().ReverseMap();
            CreateMap<Paginate<User>, Paginate<GetListUserSocialResponse>>().ReverseMap();
        }
    }
}
