using Core.Entities;

namespace Entities.Concretes;

public class StudentAnswer:Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public char SelectedOption { get; set; }
    public bool IsCorrect { get; set; }

    public User User { get; set; }
    public Question Question { get; set; }
}
