namespace Business.DTOs.SynchronLessonInstructors
{
    public class DeleteSynchronLessonInstructorRequest
    {
        public Guid InstructorName { get; set; }
        public Guid SynchronLessonName { get; set; }
    }

}
