namespace Business.DTOs.Users;

public class UpdateUserRequest
{
    public Guid Id { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? TownId { get; set; }
    public string? Description { get; set; }

}

