namespace Business.DTOs.Country
{
    public class DeletedCountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? CityId { get; set; }
    }
}
