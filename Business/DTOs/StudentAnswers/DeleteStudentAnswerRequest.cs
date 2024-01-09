namespace Business.DTOs.StudentAnswers
{
    public class DeleteStudentAnswerRequest
    {
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
