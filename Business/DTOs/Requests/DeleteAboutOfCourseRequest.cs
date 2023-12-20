namespace Business.DTOs.Requests;

public class DeleteAboutOfCourseRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime SpentTime { get; set; }
}
