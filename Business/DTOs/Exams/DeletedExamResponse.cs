﻿namespace Business.DTOs.Exams
{
    public class DeletedExamResponse
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
