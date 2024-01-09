namespace Business.DTOs.StudentAnswers
{
    public class UpdateStudentAnswerRequest
    {
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
