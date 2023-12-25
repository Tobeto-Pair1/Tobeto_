using AutoMapper;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using Business.DTOs.UserEducations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class EducationMappingProfile : Profile
{
    public EducationMappingProfile()
    {       
        CreateMap<UserEducation, CreatedUserEducationResponse>().ReverseMap();

        CreateMap<UserEducation, CreateUserEducationRequest>().ReverseMap();

        CreateMap<UserEducation, DeleteUserEducationRequest>().ReverseMap();

        CreateMap<UserEducation, DeletedUserEducationResponse>().ReverseMap();

        CreateMap<UserEducation, GetListUserEducationResponse>().ReverseMap();

        CreateMap<Paginate<UserEducation>, Paginate<GetListUserEducationResponse>>().ReverseMap();

       
    }
}
