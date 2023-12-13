using AutoMapper;
using Business.DTOs.Request;
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
        protected MappingUserProfile()
        {

            CreateMap<User, CreateUserRequest>().ReverseMap();




        }
    }
}
