using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Grades
{
    public class GetListGradeResponse
    {
        public Guid GradeId { get; set; }
        public double Score { get; set; }
    }
}
