namespace Business.DTOs.Requests
{
    public class UpdateSynchronLessonInstructorRequest
    {
        public Guid InstructorName { get; set; }
        public Guid SynchronLessonName { get; set; }
    }

}
