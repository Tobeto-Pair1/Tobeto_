using Core.DataAccess.Repositories;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class EfNotificationDal : EfRepositoryBase<NotificationType, Guid, TobetoDbContext>
{
    public EfNotificationDal(TobetoDbContext context) : base(context)
    {
    }
}
