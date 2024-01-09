using Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Exam : Entity<Guid>
    {
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }

}
