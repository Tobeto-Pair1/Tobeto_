using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Grades
{
    public class GetListGradeResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public double Score { get; set; }
    }
}
