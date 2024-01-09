using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Student : Entity<Guid>
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

}
