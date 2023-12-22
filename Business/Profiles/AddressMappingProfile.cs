using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<Address, CreatedAddressResponse>().ForMember(destinationMember: a => a.CityId,
            memberOptions: opt => opt.MapFrom(a => a.City.Id)).
            ForMember(destinationMember: a => a.CountryId,
            memberOptions: opt => opt.MapFrom(a => a.Country.Id)).
            ForMember(destinationMember: a => a.TownId,
            memberOptions: opt => opt.MapFrom(a => a.Town.Id)).ReverseMap();

        CreateMap<Address, CreateAddressRequest>().ForMember(destinationMember: a => a.CityName,
            memberOptions: opt => opt.MapFrom(a => a.City.Name)).
            ForMember(destinationMember: a => a.CountryName,
            memberOptions: opt => opt.MapFrom(a => a.Country.Name)).
            ForMember(destinationMember: a => a.TownName,
            memberOptions: opt => opt.MapFrom(a => a.Town.Name)).ReverseMap();

        CreateMap<Address, GetListAddressResponse>().
            ForMember(destinationMember: a => a.CityName,
            memberOptions: opt => opt.MapFrom(a => a.City.Name)).
            ForMember(destinationMember: a => a.CountryName,
            memberOptions: opt => opt.MapFrom(a => a.Country.Name)).
            ForMember(destinationMember: a => a.TownName,
            memberOptions: opt => opt.MapFrom(a => a.Town.Name)).
            ForMember(destinationMember: a =>a.CityId,
            memberOptions: opt=>opt.MapFrom(a=>a.City.Id)).
            ForMember(destinationMember: a => a.CountryId,
            memberOptions: opt => opt.MapFrom(a => a.Country.Id)).
            ForMember(destinationMember: a => a.TownId,
            memberOptions: opt => opt.MapFrom(a => a.Town.Id)).
            ReverseMap();
        CreateMap<Paginate<Address>, Paginate<GetListAddressResponse>>().ReverseMap();

    }

}
