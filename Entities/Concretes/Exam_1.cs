using System;
using Core.Entities;
using Entities.Concretes;

namespace Entities.Concretes
{
	public class Exam_1:Entity<Guid>
	{
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AnswerCount { get; set; }
		public double Score { get; set; }
		public Guid ExamQuestionId { get; set; }
		public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
	}
}
public class ExamQuestion : Entity<Guid>
{
	public string Name { get; set; }
    public string? OptionalQuestion { get; set; }
	public Guid ExamId { get; set; }
	public virtual Exam_1 Exam { get; set; }
}

public class ExamAnswer : Entity<Guid>
{
	public string CorrectAnswer { get; set; }
    public Guid ExamQuestionId { get; set; }
}
// soru - kişinin verdiği cevap  - basit bir kurgu  - 1 soru 4 şık var 1 cevap - question option 1-2-3-4 and answer  - hatılatılacak** 4 soru 1 cevap varmış gibi tutulacak (string)
//public class StudentAnswer:Entity<int>

	//public string? AnswerStudent { get; set; }
	//public Guid ExamQuestionId { get; set; }
	//public Guid ExamId { get; set; }
	//public Guid StudentId { get; set; }

 //   public virtual Exam_1 Exam { get; set; }



