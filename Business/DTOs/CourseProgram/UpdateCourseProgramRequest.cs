namespace Business.DTOs.CourseProgram
{
    public class UpdateCourseProgramRequest
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public Guid CourseId { get; set; }
    }
}
