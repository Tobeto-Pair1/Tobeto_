namespace Business.DTOs.AsyncLessonDetail;

public class GetListAsyncLessonDetailResponse
{
    public Guid Id { get; set; }
    public Guid? AsyncLessonId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? LessonLanguageId { get; set; }
    public Guid? SubTypeId { get; set; }
    public Guid? ManufacturerId { get; set; }

    public string AsyncLessonName { get; set; }
    public string CategoryName { get; set; }
    public string LessonLanguageName { get; set; }
    public string SubTypeName { get; set; }
    public string ManufacturerName { get; set; }
}
