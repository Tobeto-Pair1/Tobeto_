﻿namespace Business.DTOs.StudentAnswers
{
    public class CreateStudentAnswerRequest
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
