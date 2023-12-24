using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

/*Notification olarak ismi değişebilir*/
public class Notification : Entity<Guid> 
{
    public string Title { get; set; }
    public string Label { get; set; }
    public Guid NotificationTypeId { get; set; }

    public virtual NotificationType NotificationType { get; set; }
}
