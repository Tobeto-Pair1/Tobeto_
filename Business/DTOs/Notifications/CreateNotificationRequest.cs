using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Notifications
{
    public class CreateNotificationRequest
    {
        public string Title { get; set; }
        public string Label { get; set; }
    }
}
