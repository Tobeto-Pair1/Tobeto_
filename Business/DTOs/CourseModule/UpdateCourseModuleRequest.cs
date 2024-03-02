namespace Business.DTOs.CourseModule;

public class UpdateCourseModuleRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CourseId { get; set; }
}
