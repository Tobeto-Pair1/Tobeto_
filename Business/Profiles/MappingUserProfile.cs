using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class MappingUserProfile : Profile
    {
        public MappingUserProfile()
        {

            CreateMap<User, CreatedUserResponse>().ReverseMap();
            CreateMap<CreateUserRequest, User>().ReverseMap();

        }
    }
}
