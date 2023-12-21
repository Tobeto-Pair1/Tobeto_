using System;
using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
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

            CreateMap<Paginate<Town>, GetListTownResponse>().ReverseMap();
            CreateMap<Town, GetListTownResponse>().ReverseMap();

            CreateMap<Town, UpdatedTownResponse>().ReverseMap();
            CreateMap<UpdateTownRequest, Town>().ReverseMap();

            CreateMap<Town, CreatedTownResponse>().ReverseMap();
            CreateMap<CreateTownRequest, Town>().ReverseMap();


        }
	}
}

