using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SynchronLessonInstructors
{
    public class CreateSynchronLessonInstructorRequest
    {
        public Guid InstructorName { get; set; }
        public Guid SynchronLessonName { get; set; }
    }

}
