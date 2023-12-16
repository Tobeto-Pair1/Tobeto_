using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concrete;
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
        CreateMap<Address, CreatedAddressResponse>().ReverseMap();

        CreateMap<Address, CreateAddressRequest>().ReverseMap();

        CreateMap<Address, GetListAddressResponse>().
            ForMember(destinationMember: a =>a.CityId,
            memberOptions: opt=>opt.MapFrom(a=>a.City.Id)).
            ForMember(destinationMember: a => a.CountryId,
            memberOptions: opt => opt.MapFrom(a => a.Country.Id)).
            ForMember(destinationMember: a => a.TownId,
            memberOptions: opt => opt.MapFrom(a => a.Town.Id)).
            ReverseMap();
        CreateMap<Address, Paginate<GetListAddressResponse>>().ReverseMap();
    }

}
