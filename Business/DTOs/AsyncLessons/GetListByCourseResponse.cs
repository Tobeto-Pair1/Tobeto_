namespace Business.DTOs.AsyncLessons;

public class GetListByCourseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DurationTime { get; set; }
    public string Video { get; set; }
}