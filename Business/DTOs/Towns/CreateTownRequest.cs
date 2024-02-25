namespace Business.DTOs.Towns;

public class CreateTownRequest
{
    public string Name { get; set; }
    public Guid CityId { get; set; }
}

