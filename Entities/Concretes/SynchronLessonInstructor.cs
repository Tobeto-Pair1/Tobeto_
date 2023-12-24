using Core.Entities;

namespace Entities.Concretes;

public class SynchronLessonInstructor : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public Guid SynchronLessonId { get; set; }

    public virtual Instructor Instructor { get; set; }
    public virtual SynchronLesson SynchronLesson { get; set; }
}

