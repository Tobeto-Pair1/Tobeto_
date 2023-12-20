using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class UpdatedAnnouncementResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
    }
}
