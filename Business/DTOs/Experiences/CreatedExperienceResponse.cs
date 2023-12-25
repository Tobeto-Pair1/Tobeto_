namespace Business.DTOs.Experiences;

public class CreatedExperienceResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string PositionName { get; set; }
    public string SectorName { get; set; }
    public string CityName { get; set; }
    public string CountryName { get; set; }
    
    public DateTime JobStart { get; set; }
    public DateTime JobCompletion { get; set; }
    public string Description { get; set; }
}
