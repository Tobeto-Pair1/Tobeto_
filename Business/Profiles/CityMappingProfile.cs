using AutoMapper;
using Business.DTOs.Cities;
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

            CreateMap<City, CreateCityRequest>().
                ForMember(destinationMember: a => a.CountryName,
            memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            //    ForMember(destinationMember: a => a.CityName,
            //memberOptions: opt => opt.MapFrom(a => a.Address.City.Name)).
            //    ForMember(destinationMember: a => a.TownName,
            //memberOptions: opt => opt.MapFrom(a => a.Address.Town.Name)).
            //    ForMember(destinationMember: a => a.Description,
            //memberOptions: opt => opt.MapFrom(a => a.Address.Description))
                .ReverseMap();

            CreateMap<City, DeleteCityRequest>().ReverseMap();

            CreateMap<City, DeletedCityResponse>().ReverseMap();
            CreateMap<City, UpdateCityRequest>().ReverseMap();

            CreateMap<City, UpdatedCityResponse>().ReverseMap();

            CreateMap<City, GetListCityResponse>().ReverseMap();

            CreateMap<Paginate<City>, Paginate<GetListCityResponse>>().ReverseMap();
        }
    }
}
