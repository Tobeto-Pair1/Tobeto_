namespace Business.DTOs.Responses
{
    public class UpdatedSynchronLessonInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid SynchronLessonId { get; set; }
    }
}
