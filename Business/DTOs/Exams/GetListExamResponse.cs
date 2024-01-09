using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Exams
{
    public class GetListExamResponse
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
