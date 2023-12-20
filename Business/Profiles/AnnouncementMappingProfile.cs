using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AnnouncementMappingProfile:Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<Announcement, CreatedAnnouncementResponse>().ReverseMap();

            CreateMap<Announcement, CreateAnnouncementRequest>().ReverseMap();

            CreateMap<Announcement, DeleteAnnouncementRequest>().ReverseMap();

            CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();
            CreateMap<Announcement, UpdateAnnouncementRequest>().ReverseMap();

            CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();

            CreateMap<Announcement, GetListAnnouncementResponse>().ReverseMap();

            CreateMap<Paginate<Announcement>, Paginate<GetListAnnouncementResponse>>().ReverseMap();
        }
    }
}
