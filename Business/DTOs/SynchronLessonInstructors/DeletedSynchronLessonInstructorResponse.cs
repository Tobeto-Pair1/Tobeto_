namespace Business.DTOs.SynchronLessonInstructors
{
    public class DeletedSynchronLessonInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid SynchronLessonId { get; set; }
    }
}
