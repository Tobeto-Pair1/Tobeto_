using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class CourseModule : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }
}
