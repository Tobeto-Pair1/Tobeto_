namespace Business.DTOs.Country
{
    public class UpdatedCountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? CityId { get; set; }
    }
}
