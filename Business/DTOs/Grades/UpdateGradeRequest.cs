namespace Business.DTOs.Grades
{
    public class UpdateGradeRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public double Score { get; set; }
    }
}
