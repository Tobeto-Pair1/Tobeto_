using AutoMapper;
using Business.DTOs.Programs;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ProgramMappingProfile : Profile
    {
        public ProgramMappingProfile()
        {
            CreateMap<Program, CreatedProgramResponse>().ReverseMap();

            CreateMap<Program, CreateProgramRequest>().ReverseMap();

            CreateMap<Program, DeleteProgramRequest>().ReverseMap();

            CreateMap<Program, DeletedProgramResponse>().ReverseMap();
            CreateMap<Program, UpdateProgramRequest>().ReverseMap();

            CreateMap<Program, UpdatedProgramResponse>().ReverseMap();

            CreateMap<Program, GetListProgramResponse>().ReverseMap();

            CreateMap<Paginate<Program>, Paginate<GetListProgramResponse>>().ReverseMap();
        }
    }
}
