namespace Business.DTOs.AsyncLessonDetail
{
    public class UpdatedAsyncLessonDetailResponse
    {
        public Guid Id { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public string AsyncLessonName { get; set; }
        public string LessonLanguageName { get; set; }
        public string SubTypeName { get; set; }
    }
}
