using AutoMapper;
using Business.DTOs.Manufacturers;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ManufacturerMappingProfile: Profile
    {
        public ManufacturerMappingProfile()
        {

            CreateMap<Manufacturer, CreateManufacturerRequest>().ReverseMap();
            CreateMap<Manufacturer, CreatedManufacturerResponse>().ReverseMap();


            CreateMap<Manufacturer, UpdateManufacturerRequest>().ReverseMap();
            CreateMap<Manufacturer, UpdatedManufacturerResponse>().ReverseMap();


            CreateMap<Manufacturer, DeleteManufacturerRequest>().ReverseMap();
            CreateMap<Manufacturer, DeletedManufacturerResponse>().ReverseMap();


            CreateMap<Manufacturer, GetListManufacturerResponse>().ReverseMap();
            CreateMap<Paginate<Manufacturer>, Paginate<GetListManufacturerResponse>>().ReverseMap();
        }
    }
}
