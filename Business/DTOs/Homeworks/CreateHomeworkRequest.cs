using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Homeworks
{
    public class CreateHomeworkRequest
    {
        public Guid Id { get; set; }
        public bool HomeWorkIsSend { get; set; }
        public string InstructorDescription { get; set; }
        public string StudentDescription { get; set; }
        public DateTime LastDate { get; set; }
        public string HomeworkTaskFile { get; set; }

    }
}
