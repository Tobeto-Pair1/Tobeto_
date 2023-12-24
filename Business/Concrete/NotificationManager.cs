using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
        IMapper _mapper;
        public NotificationManager(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<CreatedNotificationResponse> Add(CreateNotificationRequest createNotificationRequest)
        {
            Notification notification = _mapper.Map<Notification>(createNotificationRequest);
            Notification createdNotification = await _notificationDal.AddAsync(notification);
            CreatedNotificationResponse createdNotificationResponse = _mapper.Map<CreatedNotificationResponse>(createdNotification);
            return createdNotificationResponse;
        }

        public  async Task<DeletedNotificationResponse> Delete(DeleteNotificationRequest deleteNotificationRequest)
        {
            Notification notification = _mapper.Map<Notification>(deleteNotificationRequest);
            Notification deletedNotification = await _notificationDal.DeleteAsync(notification);
            DeletedNotificationResponse deletedNotificationResponse = _mapper.Map<DeletedNotificationResponse>(deletedNotification);
            return deletedNotificationResponse;
        }

        public async Task<IPaginate<GetListNotificationResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _notificationDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListNotificationResponse>>(data);
            return result;
        }

        public async Task<UpdatedNotificationResponse> Update(UpdateNotificationRequest updateNotificationRequest)
        {
            Notification notification = _mapper.Map<Notification>(updateNotificationRequest);
            Notification updateNotification = await _notificationDal.UpdateAsync(notification);
            UpdatedNotificationResponse updatedNotificationResponse = _mapper.Map<UpdatedNotificationResponse>(updateNotification);
            return updatedNotificationResponse;
        }
    }
}
