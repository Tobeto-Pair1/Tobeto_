using AutoMapper;
using Business.DTOs.AsyncLessons;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles
{
    public  class AsyncLessonMappingProfile:Profile
    {


         public AsyncLessonMappingProfile() 
        {

            CreateMap<AsyncLesson, CreatedAsyncLessonResponse>().ReverseMap();
            CreateMap<AsyncLesson, CreateAsyncLessonRequest>().ReverseMap();

            CreateMap<AsyncLesson, UpdatedAsyncLessonResponse>().ReverseMap();
            CreateMap<AsyncLesson, UpdateAsyncLessonRequest>().ReverseMap();

            CreateMap<AsyncLesson, DeleteAsyncLessonRequest>().ReverseMap();
            CreateMap<AsyncLesson, DeletedAsyncLessonResponse>().ReverseMap();

            CreateMap<AsyncLesson, GetListAsyncLessonResponse>().ReverseMap();
            CreateMap<Paginate<AsyncLesson>,Paginate<GetListAsyncLessonResponse>>().ReverseMap();




        }
    }
}
