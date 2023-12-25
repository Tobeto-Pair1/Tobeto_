namespace Business.DTOs.SynchronLessonInstructors
{
    public class CreatedSynchronLessonInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid SynchronLessonId { get; set; }
    }
}
