using Core.Entities;

namespace Entities.Concretes;

public class Grade : Entity<Guid>
{
    public double Score { get; set; }


    public User User { get; set; }
    public Exam Exam { get; set; }

}
