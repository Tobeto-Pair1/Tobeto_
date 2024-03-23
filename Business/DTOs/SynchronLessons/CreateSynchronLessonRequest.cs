namespace Business.DTOs.SynchronLessons;

public class CreateSynchronLessonRequest
{
    public Guid CourseModuleId { get; set; }
    public string SessionName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime TimeSpent { get; set; }
}
