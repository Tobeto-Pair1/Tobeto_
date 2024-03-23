using Core.Entities;


namespace Entities.Concretes;

public class CourseModule : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }
    public virtual ICollection<SynchronLesson> SynchronLessons { get; set; }
    public virtual SynchronLessonDetail SynchronLessonDetail { get; set; }
}
