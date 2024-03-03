namespace Business.DTOs.SynchronLessonInstructors
{
    public class UpdateSynchronLessonInstructorRequest
    {
        public Guid Id { get; set; }
        public Guid InstructorName { get; set; }
        public Guid SynchronLessonName { get; set; }
    }

}
