﻿namespace Business.DTOs.AsyncLessonDetail;

public class UpdatedAsyncLessonDetailResponse
{
    public Guid Id { get; set; }
    public Guid? ManufacturerId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? AsyncLessonId { get; set; }
    public Guid? LessonLanguageId { get; set; }
    public Guid? SubTypeId { get; set; }
}
