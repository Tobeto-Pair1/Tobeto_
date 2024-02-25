namespace Business.DTOs.Towns;

public class CreatedTownResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
}

