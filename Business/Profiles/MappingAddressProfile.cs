using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class MappingAddressProfile : Profile
    {
        public MappingAddressProfile()
        {
            CreateMap<Address, CreatedAddressResponse>().ReverseMap();
            CreateMap<CreateAddressRequest, Address>().ReverseMap();

            CreateMap<Address, GetListAddressResponse>().ReverseMap();
        }

    }
}
