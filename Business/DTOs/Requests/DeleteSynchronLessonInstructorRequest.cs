namespace Business.DTOs.Requests
{
    public class DeleteSynchronLessonInstructorRequest
    {
        public Guid InstructorName { get; set; }
        public Guid SynchronLessonName { get; set; }
    }

}
