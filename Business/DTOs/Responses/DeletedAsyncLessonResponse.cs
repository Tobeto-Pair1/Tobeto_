namespace Business.DTOs.Responses
{
    public class DeletedAsyncLessonResponse
    {
        public string Name { get; set; }
        public DateTime DurationTime { get; set; } 
        public DateTime TimeSpent { get; set; }
        public Guid InstructorId { get; set; }

        public Guid CourseModuleId { get; set; }

    }
}
