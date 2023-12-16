using System;
using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
	public class MappingTownProfile : Profile
	{
		public MappingTownProfile()
		{
            CreateMap<Town, CreatedTownResponse>().ReverseMap();
            CreateMap<CreateTownRequest, Town>().ReverseMap();

            CreateMap<Town, GetListTownResponse>().ReverseMap();
            CreateMap<PageRequest, Town>().ReverseMap();//

            CreateMap<Town, UpdatedTownResponse>().ReverseMap();
            CreateMap<UpdateTownRequest, Town>().ReverseMap();

            CreateMap<Town, CreatedTownResponse>().ReverseMap();
            CreateMap<CreateTownRequest, Town>().ReverseMap();


        }
	}
}

