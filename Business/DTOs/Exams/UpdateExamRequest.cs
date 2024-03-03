namespace Business.DTOs.Exams
{
    public class UpdateExamRequest
    {
        public Guid Id { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
