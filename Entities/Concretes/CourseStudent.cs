using Core.Entities;

namespace Entities.Concretes;

public class CourseStudent : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual User User { get; set; }

}