using AutoMapper;
using Business.DTOs.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class NewMappingProfile:Profile
    {   
        public NewMappingProfile() 
        {
            CreateMap<New, CreatedNewResponse>().ReverseMap();

            CreateMap<New, CreateNewRequest>().ReverseMap();

            CreateMap<New, DeleteNewRequest>().ReverseMap();

            CreateMap<New, DeletedNewResponse>().ReverseMap();
            CreateMap<New, UpdateNewRequest>().ReverseMap();

            CreateMap<New, UpdatedNewResponse>().ReverseMap();


            CreateMap<New, GetListNewResponse>().
                ForMember(destinationMember: a => a.NotificationId,
                memberOptions: opt => opt.MapFrom(a => a.NotificationType.Id)).
                ReverseMap();
            CreateMap<Paginate<New>, Paginate<GetListNewResponse>>().ReverseMap();
        }
       
    }
}
