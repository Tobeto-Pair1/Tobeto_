using AutoMapper;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserEducationMappingProfile:Profile
    {
        public UserEducationMappingProfile()
        {
            CreateMap<UserEducation, CreatedUserEducationResponse>().ReverseMap();

            CreateMap<UserEducation, CreateUserEducationRequest>().ReverseMap();

            CreateMap<UserEducation, DeletedUserEducationResponse>().ReverseMap();

            CreateMap<UserEducation, DeleteUserEducationRequest>().ReverseMap();

            CreateMap<UserEducation, UpdatedUserEducationResponse>().ReverseMap();

            CreateMap<UserEducation, UpdateUserEducationRequest>().ReverseMap();

            CreateMap<UserEducation, GetListUserEducationResponse>();

            CreateMap<Paginate<UserEducation>, Paginate<GetListUserEducationResponse>>().ReverseMap();
        }
    }
}
