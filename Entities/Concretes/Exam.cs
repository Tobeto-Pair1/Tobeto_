using System;
using Core.Entities;
using Entities.Concretes;

namespace Entities.Concretes
{
	public class Exam:Entity<int>
	{
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AnswerCount { get; set; }
		public double Score { get; set; }
		public int ExamQuestionId { get; set; }

		public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }

	}
}
public class ExamQuestion : Entity<int>
{
	public string Name { get; set; }
    public string? OptionalQuestion { get; set; }

	public int ExamId { get; set; }

	public virtual Exam Exam { get; set; }
}

public class ExamAnswer : Entity<int>
{
	public string CorrectAnswer { get; set; }
    public int ExamQuestionId { get; set; }
}

public class StudentAnswer:Entity<int>
{
	public string? AnswerStudent { get; set; }
	public int ExamQuestionId { get; set; }
	public int ExamId { get; set; }
	public int StudentId { get; set; }

    public virtual Exam Exam { get; set; }

} 

