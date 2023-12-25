using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.AsyncLessons;

public class CreateAsyncLessonRequest
{
    public string Name { get; set; }
    public DateTime DurationTime { get; set; }
    public DateTime TimeSpent { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseModuleId { get; set; }

    /*public string InstructorName { get; set; }
    public string CourseModuleName { get; set; }*/
}
