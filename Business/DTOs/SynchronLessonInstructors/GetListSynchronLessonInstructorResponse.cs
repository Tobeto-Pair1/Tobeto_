using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SynchronLessonInstructors
{
    public class GetListSynchronLessonInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid SynchronLessonId { get; set; }
    }
}
