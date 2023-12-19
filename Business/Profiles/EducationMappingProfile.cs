﻿using AutoMapper;
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
        CreateMap<UserEducation, CreatedEducationResponse>().ReverseMap();

        CreateMap<UserEducation, CreateEducationRequest>().ReverseMap();

        CreateMap<UserEducation, DeleteEducationRequest>().ReverseMap();

        CreateMap<UserEducation, DeletedEducationResponse>().ReverseMap();

        CreateMap<UserEducation, GetListEducationResponse>().ReverseMap();

        CreateMap<Paginate<UserEducation>, Paginate<GetListEducationResponse>>().ReverseMap();

       
    }
}
