using AutoMapper;
using Business.DTOs.Cities;
using Business.DTOs.StudentAnswers;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentAnswerMappingProfile:Profile
    {
        public StudentAnswerMappingProfile()
        {
            CreateMap<StudentAnswer, CreatedStudentAnswerResponse>().ReverseMap();

            CreateMap<StudentAnswer, CreateStudentAnswerRequest>().ReverseMap();

            CreateMap<StudentAnswer, DeleteStudentAnswerRequest>().ReverseMap();

            CreateMap<StudentAnswer, DeletedStudentAnswerResponse>().ReverseMap();
            CreateMap<StudentAnswer, UpdateStudentAnswerRequest>().ReverseMap();

            CreateMap<StudentAnswer, UpdatedStudentAnswerResponse>().ReverseMap();

            CreateMap<StudentAnswer, GetListStudentAnswerResponse>().ReverseMap();

            CreateMap<Paginate<StudentAnswer>, Paginate<GetListStudentAnswerResponse>>().ReverseMap();
        }
    }
}
