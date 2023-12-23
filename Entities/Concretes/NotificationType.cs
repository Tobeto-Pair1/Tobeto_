using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;


public class NotificationType : Entity<Guid>
{
    public string Name { get; set; } //haber, duyuru


    public virtual ICollection <New> News { get; set; }
    public virtual ICollection<Announcement> Announcements { get; set; }


    //public virtual ICollection<Notification> Notification { get; set; }


}
