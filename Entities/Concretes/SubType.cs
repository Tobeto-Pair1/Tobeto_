using Core.Entities;

namespace Entities.Concretes;

public class SubType : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<SynchronLessonDetail> SynchronLessonDetails { get; set; }
    public virtual ICollection<AsyncLessonDetail> AsyncLessonDetails { get; set; }
}