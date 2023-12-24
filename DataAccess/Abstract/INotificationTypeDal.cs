using Core.DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;

public interface INotificationTypeDal : IRepository<NotificationType , Guid> , IAsyncRepository<NotificationType , Guid>
{
}