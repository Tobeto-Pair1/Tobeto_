using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

using Core.DataAccess.Dynamic;

using System.Threading.Tasks;

namespace Business.Profiles
{
    public class HomeworkMappingProfile: Profile
    {

        public HomeworkMappingProfile() 
        {
            CreateMap<Homework, CreatedHomeworkResponse>().ReverseMap();
            CreateMap<Homework, CreateHomeworkRequest>().ReverseMap();

            CreateMap<Homework, UpdatedHomeworkResponse>().ReverseMap();
            CreateMap<Homework, UpdateHomeworkRequest>().ReverseMap();

            CreateMap<Homework, DeleteHomeworkRequest>().ReverseMap();
            CreateMap<Homework, DeletedHomeworkResponse>().ReverseMap();

            CreateMap<Homework, GetListHomeworkResponse>().ReverseMap();
            CreateMap<Paginate<Homework>, Paginate<GetListHomeworkResponse>>().ReverseMap();
        }

    }
}
