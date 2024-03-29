﻿using AutoMapper;
using Business.DTOs.Country;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class CountryMappingProfile:Profile
{
    public CountryMappingProfile()
    {

        CreateMap<Country, CreateCountryRequest>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();


        CreateMap<Country, UpdateCountryRequest>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();


        CreateMap<Country, DeleteCountryRequest>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();

       
        CreateMap<Country, GetListCountryResponse>().ReverseMap();
        CreateMap<Paginate<Country>, Paginate<GetListCountryResponse>>().ReverseMap();
    }
}
