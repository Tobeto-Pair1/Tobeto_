namespace Business.DTOs.CourseStudent;

public class CreatedCourseStudentResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}
