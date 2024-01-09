namespace Business.DTOs.Country
{
    public class CreateCountryRequest
    {
        public string? Name { get; set; }
        public Guid? CityId { get; set; }
    }
}
