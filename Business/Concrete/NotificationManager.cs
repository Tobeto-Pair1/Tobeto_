using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.DTOs.Notifications;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;
    private readonly IMapper _mapper;
    public NotificationManager(IMapper mapper, INotificationDal notificationDal)
    {
        _mapper = mapper;
        _notificationDal = notificationDal;
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
        Notification notification = await _notificationDal.GetAsync(u => u.Id == deleteNotificationRequest.Id);
        _mapper.Map(deleteNotificationRequest, notification);
        Notification deletedNotification = await _notificationDal.DeleteAsync(notification);
        DeletedNotificationResponse deletedNotificationResponse = _mapper.Map<DeletedNotificationResponse>(deletedNotification);
        return deletedNotificationResponse;
    }

    //[SecuredOperation("admin")]
    public async Task<IPaginate<GetListNotificationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _notificationDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListNotificationResponse>>(data);
        return result;
    }

    public async Task<UpdatedNotificationResponse> Update(UpdateNotificationRequest updateNotificationRequest)
    {
        Notification notification = await _notificationDal.GetAsync(u => u.Id == updateNotificationRequest.Id);
        _mapper.Map(updateNotificationRequest, notification);
        Notification updateNotification = await _notificationDal.UpdateAsync(notification);
        UpdatedNotificationResponse updatedNotificationResponse = _mapper.Map<UpdatedNotificationResponse>(updateNotification);
        return updatedNotificationResponse;
    }
}
