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
            CreateMap<UserSocial, CreateUserSocialRequest>().ReverseMap();

            CreateMap<UserSocial, DeletedUserSocialResponse>().ReverseMap();
            CreateMap<UserSocial, DeleteUserSocialRequest>().ReverseMap();

            CreateMap<UserSocial, UpdatedUserSocialResponse>().ReverseMap();
            CreateMap<UserSocial, UpdateUserSocialRequest>().ReverseMap();

            CreateMap<UserSocial, GetListUserSocialResponse>().ReverseMap();
            CreateMap<Paginate<UserSocial>, Paginate<GetListUserSocialResponse>>().ReverseMap();
        }
    }
}
