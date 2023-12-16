using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concrete;
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

        }
    }
}
