using AutoMapper;
using Business.DTOs.Notifications;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class NotificationMappingProfile:Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, CreatedNotificationResponse>().ReverseMap();

            CreateMap<Notification, CreateNotificationRequest>().ReverseMap();

            CreateMap<Notification, DeleteNotificationRequest>().ReverseMap();

            CreateMap<Notification, DeletedNotificationResponse>().ReverseMap();
            CreateMap<Notification, UpdateNotificationRequest>().ReverseMap();

            CreateMap<Notification, UpdatedNotificationResponse>().ReverseMap();

            CreateMap<Notification, GetListNotificationResponse>().ReverseMap();

            CreateMap<Paginate<Notification>, Paginate<GetListNotificationResponse>>().ReverseMap();
        }
    }
}
