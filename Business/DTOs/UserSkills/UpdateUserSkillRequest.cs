namespace Business.DTOs.Requests;

public class UpdateUserSkillRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SkillId { get; set; }
}
