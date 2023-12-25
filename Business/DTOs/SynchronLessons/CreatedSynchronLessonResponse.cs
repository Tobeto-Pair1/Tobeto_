using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SynchronLessons
{
    public class CreatedSynchronLessonResponse
    {
        public Guid Id { get; set; }
        public DateTime DurationTime { get; set; }
        public DateTime TimeSpent { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid InstructorId { get; set; }
    }
}
