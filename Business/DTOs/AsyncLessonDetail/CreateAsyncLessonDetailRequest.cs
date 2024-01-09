namespace Business.DTOs.AsyncLessonDetail
{
    public class CreateAsyncLessonDetailRequest
    {
        public Guid? ManufacturerId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AsyncLessonId { get; set; }
        public Guid? LessonLanguageId { get; set; }
        public Guid? SubTypeId { get; set; }
    }
}
