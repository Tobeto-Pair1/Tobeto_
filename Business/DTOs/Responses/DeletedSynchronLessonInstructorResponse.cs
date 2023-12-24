namespace Business.DTOs.Responses
{
    public class DeletedSynchronLessonInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid SynchronLessonId { get; set; }
    }
}
