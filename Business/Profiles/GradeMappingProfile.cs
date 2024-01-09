using AutoMapper;
using Business.DTOs.Cities;
using Business.DTOs.Grades;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class GradeMappingProfile:Profile
    {
        public GradeMappingProfile()
        {
            CreateMap<Grade, CreatedGradeResponse>().ReverseMap();

            CreateMap<Grade, CreateGradeRequest>().ReverseMap();

            CreateMap<Grade, DeleteGradeRequest>().ReverseMap();

            CreateMap<Grade, DeletedGradeResponse>().ReverseMap();
            CreateMap<Grade, UpdateGradeRequest>().ReverseMap();

            CreateMap<Grade, UpdatedGradeResponse>().ReverseMap();

            CreateMap<Grade, GetListGradeResponse>().ReverseMap();

            CreateMap<Paginate<Grade>, Paginate<GetListGradeResponse>>().ReverseMap();
        }
    }
}
