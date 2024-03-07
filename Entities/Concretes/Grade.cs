using Core.Entities;

namespace Entities.Concretes;

public class Grade : Entity<Guid>
{
    public double Score { get; set; }
    public Guid UserId { get; set; }
    public Guid ExamId { get; set; }

    public User User { get; set; }
    public Exam Exam { get; set; }

}
