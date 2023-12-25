namespace Business.DTOs.Instructors;

public class GetListInstructorResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; }
}