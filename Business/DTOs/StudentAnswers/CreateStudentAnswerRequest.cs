namespace Business.DTOs.StudentAnswers
{
    public class CreateStudentAnswerRequest
    {
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
