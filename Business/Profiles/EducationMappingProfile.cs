using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
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
        CreateMap<Education, CreatedEducationResponse>().ReverseMap();

        CreateMap<Education, CreateEducationRequest>().ReverseMap();

        CreateMap<Education, DeleteEducationRequest>().ReverseMap();

        CreateMap<Education, DeletedEducationResponse>().ReverseMap();

        CreateMap<Education, GetListEducationResponse>().ReverseMap();

        CreateMap<Paginate<Education>, Paginate<GetListEducationResponse>>().ReverseMap();

       
    }
}
