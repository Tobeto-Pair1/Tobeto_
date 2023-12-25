namespace Business.DTOs.Responses
{
    public class UpdatedSynchronLessonDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LessonLanguageId { get; set; }
        public Guid SubTypeId { get; set; }
    }
}
