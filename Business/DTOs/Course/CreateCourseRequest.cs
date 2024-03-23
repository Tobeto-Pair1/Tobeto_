namespace Business.DTOs.Course;

public class CreateCourseRequest
{
    public Guid? ImageId { get; set; }
    public Guid CourseTypeId { get; set; }
    public string Name { get; set; }
}
