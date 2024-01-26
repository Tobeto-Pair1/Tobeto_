namespace Business.DTOs.Course
{
    public class CreateCourseRequest
    {
        public string Name { get; set; }
        public Guid CourseTypeId { get; set; }
    }
}
