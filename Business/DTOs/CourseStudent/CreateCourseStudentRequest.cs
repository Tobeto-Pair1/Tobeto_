namespace Business.DTOs.CourseStudent;

public class CreateCourseStudentRequest
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}
