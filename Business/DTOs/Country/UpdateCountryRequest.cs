namespace Business.DTOs.Country
{
    public class UpdateCountryRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
