using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Course
{
    public class GetListCourseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseTypeId { get; set; }

    }
}
