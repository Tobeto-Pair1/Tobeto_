using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class CreatedAnnouncementResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
    }
}
