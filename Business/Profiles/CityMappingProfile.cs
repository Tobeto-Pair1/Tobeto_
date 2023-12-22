using AutoMapper;
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
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CreatedCityResponse>().ReverseMap();

            CreateMap<City, CreateCityRequest>().ReverseMap();

            CreateMap<City, DeleteCityRequest>().ReverseMap();

            CreateMap<City, DeletedCityResponse>().ReverseMap();
            CreateMap<City, UpdateCityRequest>().ReverseMap();

            CreateMap<City, UpdatedCityResponse>().ReverseMap();

            CreateMap<City, GetListCityResponse>().ReverseMap();

            CreateMap<Paginate<City>, Paginate<GetListCityResponse>>().ReverseMap();
        }
    }
}
