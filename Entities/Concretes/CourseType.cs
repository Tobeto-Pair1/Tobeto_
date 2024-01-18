using Core.Entities;

namespace Entities.Concretes;

public class CourseType : Entity<Guid>
{
    
    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
    //public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }
    //public virtual ICollection<SynchronLesson> SynchronLessons { get; set; }
}
