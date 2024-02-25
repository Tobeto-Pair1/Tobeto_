using AutoMapper;
using Business.DTOs.Cities;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

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
