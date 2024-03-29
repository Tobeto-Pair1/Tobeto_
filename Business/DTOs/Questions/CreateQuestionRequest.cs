﻿namespace Business.DTOs.Questions
{
    public class CreateQuestionRequest
    {
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public char CorrectAnswer { get; set; }
        public Guid ExamId { get; set; }

    }
}
