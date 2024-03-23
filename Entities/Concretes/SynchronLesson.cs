using Core.Entities;

namespace Entities.Concretes;

public class SynchronLesson : Entity<Guid>
{
    public Guid CourseModuleId { get; set; }
    public string SessionName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime TimeSpent { get; set; }

    public virtual CourseModule CourseModule { get; set; }
    public virtual ICollection<SynchronLessonInstructor> SynchronLessonInstructor { get; set; }
}

