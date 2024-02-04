namespace Business.DTOs.CourseStudent
{
    public class UpdateCourseStudentRequest
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
