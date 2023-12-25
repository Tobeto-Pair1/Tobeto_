using AutoMapper;
using Business.DTOs.SubTypes;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SubTypeMappingProfile : Profile
    {
        public SubTypeMappingProfile()
        {

            CreateMap<SubType, CreatedSubTypeResponse>().ReverseMap();

            CreateMap<SubType, CreateSubTypeRequest>().ReverseMap();

            CreateMap<SubType, DeleteSubTypeRequest>().ReverseMap();

            CreateMap<SubType, DeletedSubTypeResponse>().ReverseMap();
            CreateMap<SubType, UpdateSubTypeRequest>().ReverseMap();

            CreateMap<SubType, UpdatedSubTypeResponse>().ReverseMap();

            CreateMap<SubType, GetListSubTypeResponse>().ReverseMap();

            CreateMap<Paginate<SubType>, Paginate<GetListSubTypeResponse>>().ReverseMap();
        }
    }
}
