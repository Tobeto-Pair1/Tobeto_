namespace Business.DTOs.Users;

public class UpdatedUserResponse
{
    public Guid Id { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string? AboutMe { get; set; }
    public Guid AdrressId { get; set; }
}
