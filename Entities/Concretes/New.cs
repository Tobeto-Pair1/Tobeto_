using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class New : Entity<Guid>
{

    public string Title { get; set; }
    public string Label { get; set; }

    public Guid NotificationId { get; set; }
    public NotificationType NotificationType { get; set; }




}
