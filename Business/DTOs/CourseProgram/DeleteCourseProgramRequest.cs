namespace Business.DTOs.CourseProgram
{
    public class DeleteCourseProgramRequest
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public Guid CourseId { get; set; }
    }
}
