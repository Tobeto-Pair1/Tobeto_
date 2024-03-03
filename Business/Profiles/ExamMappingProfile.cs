using AutoMapper;
using Business.DTOs.Exams;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class ExamMappingProfile:Profile
{
    public ExamMappingProfile()
    {
        CreateMap<Exam, CreatedExamResponse>().ReverseMap();

        CreateMap<Exam, CreateExamRequest>().ReverseMap();

        CreateMap<Exam, DeleteExamRequest>().ReverseMap();

        CreateMap<Exam, DeletedExamResponse>().ReverseMap();
        CreateMap<Exam, UpdateExamRequest>().ReverseMap();

        CreateMap<Exam, UpdatedExamResponse>().ReverseMap();

        CreateMap<Exam, GetListExamResponse>().ReverseMap();

        CreateMap<Paginate<Exam>, Paginate<GetListExamResponse>>().ReverseMap();
    }
}
