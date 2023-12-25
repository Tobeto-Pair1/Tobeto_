namespace Business.DTOs.Cities;

public class CreatedCityResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
}
