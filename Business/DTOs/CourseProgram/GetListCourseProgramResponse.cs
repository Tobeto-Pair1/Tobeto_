using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.CourseProgram
{
    public class GetListCourseProgramResponse
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public Guid CourseId { get; set; }

    }
}
