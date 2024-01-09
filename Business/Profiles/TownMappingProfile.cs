using AutoMapper;
using Business.DTOs.Towns;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class TownMappingProfile:Profile
    {
        public TownMappingProfile()
        {

            CreateMap<Town, CreatedTownResponse>().ReverseMap();
            CreateMap<Town, CreateTownRequest>()
                //    .
                //    ForMember(destinationMember: a => a.AddressId,
                //memberOptions: opt => opt.MapFrom(a => a.Address.Id)) 
                .ReverseMap();

            CreateMap<Town, DeletedTownResponse>().ReverseMap();
            CreateMap<DeleteTownRequest, Town>().ReverseMap();

            CreateMap<Town, UpdatedTownResponse>().ReverseMap();
            CreateMap<UpdateTownRequest, Town>().ReverseMap();

            CreateMap<Town, GetListTownResponse>()
                .ForMember(destinationMember: a => a.CityName,
           memberOptions: opt => opt.MapFrom(a => a.City.Name))
                .ReverseMap();
            CreateMap<Paginate<Town>, Paginate<GetListTownResponse>>().ReverseMap();
        }
    }
}
