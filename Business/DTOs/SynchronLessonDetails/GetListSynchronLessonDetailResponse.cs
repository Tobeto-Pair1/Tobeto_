namespace Business.DTOs.SynchronLessonDetails;

public class GetListSynchronLessonDetailResponse
{
    public Guid Id { get; set; }
    public Guid CourseModuleId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LessonLanguageId { get; set; }
    public Guid SubTypeId { get; set; }
    public string CourseModuleName { get; set; }
    public string CategoryName { get; set; }
    public string LessonLanguageName { get; set; }
    public string SubTypeName { get; set; }
}
