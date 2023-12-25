namespace Business.DTOs.Homeworks;

public class CreatedHomeworkResponse
{
    public string Name { get; set; }
    public Guid CourseId { get; set; }
    public Guid SynchronLessonDetailId { get; set; }
    public string InstructorDescription { get; set; }
    public string StudentDescription { get; set; }
    public DateTime LastDate { get; set; }
    public string HomeworkTaskFile { get; set; }
    public string HomeworkSentFile { get; set; }

}




