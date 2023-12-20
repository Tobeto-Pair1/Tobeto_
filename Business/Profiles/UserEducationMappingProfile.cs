using System;
using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
	public class UserEducationMappingProfile:Profile
	{
        UserEducationMappingProfile()
        {
            CreateMap<UserEducation, CreatedUserEducationResponse>().ReverseMap();
            CreateMap<CreateUserEducationRequest, Town>().ReverseMap();

            CreateMap<Town, GetListTownResponse>().ReverseMap();
            CreateMap<PageRequest, Town>().ReverseMap();

            CreateMap<Town, UpdatedTownResponse>().ReverseMap();
            CreateMap<UpdateTownRequest, Town>().ReverseMap();

            CreateMap<Town, CreatedTownResponse>().ReverseMap();
            CreateMap<CreateTownRequest, Town>().ReverseMap();
        }
      
    }
}

