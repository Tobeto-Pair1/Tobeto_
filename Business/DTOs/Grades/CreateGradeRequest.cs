namespace Business.DTOs.Grades
{
    public class CreateGradeRequest
    {
        public double Score { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
    }
}
