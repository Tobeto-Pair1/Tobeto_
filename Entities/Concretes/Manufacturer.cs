using Core.Entities;

namespace Entities.Concretes;

public class Manufacturer:Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<AboutOfCourse> AboutOfCourses { get; set; }
    public virtual ICollection<AsyncLessonDetail> AsyncLessonDetail { get; set; }
    public virtual ICollection<SynchronLessonDetail> SynchronLessonDetails { get; set; }
}

