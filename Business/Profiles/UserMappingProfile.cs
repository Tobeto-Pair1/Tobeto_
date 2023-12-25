using AutoMapper;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<User, CreatedUserResponse>().ReverseMap();
            CreateMap<CreateUserRequest, User>().ReverseMap();

            CreateMap<User, DeletedUserResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, User>().ReverseMap();

            CreateMap<User, UpdatedUserResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, User>().ReverseMap();

            CreateMap<User, GetListUserResponse>().ReverseMap();
            CreateMap<Paginate<User>,Paginate<GetListUserResponse>>().ReverseMap();

        }
    }
}
