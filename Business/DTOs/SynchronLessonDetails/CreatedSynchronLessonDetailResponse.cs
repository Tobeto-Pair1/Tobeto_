namespace Business.DTOs.SynchronLessonDetails;

public class CreatedSynchronLessonDetailResponse
{
    public Guid Id { get; set; }
    public Guid CourseModuleId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LessonLanguageId { get; set; }
    public Guid SubTypeId { get; set; }
}
