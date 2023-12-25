using Business.DTOs.Notifications;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        Task<IPaginate<GetListNotificationResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedNotificationResponse> Add(CreateNotificationRequest createAnnouncementRequest);

        Task<UpdatedNotificationResponse> Update(UpdateNotificationRequest updateAnnouncementRequest);

        Task<DeletedNotificationResponse> Delete(DeleteNotificationRequest deleteAnnouncementRequest);
    }
}
