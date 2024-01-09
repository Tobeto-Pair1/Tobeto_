using AutoMapper;
using Business.DTOs.Cities;
using Business.DTOs.Questions;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class QuestionMappingProfile:Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, CreatedQuestionResponse>().ReverseMap();

            CreateMap<Question, CreateQuestionRequest>().ReverseMap();

            CreateMap<Question, DeleteQuestionRequest>().ReverseMap();

            CreateMap<Question, DeletedQuestionResponse>().ReverseMap();
            CreateMap<Question, UpdateQuestionRequest>().ReverseMap();

            CreateMap<Question, UpdatedQuestionResponse>().ReverseMap();

            CreateMap<Question, GetListQuestionResponse>().ReverseMap();

            CreateMap<Paginate<Question>, Paginate<GetListQuestionResponse>>().ReverseMap();
        }
    }
}
