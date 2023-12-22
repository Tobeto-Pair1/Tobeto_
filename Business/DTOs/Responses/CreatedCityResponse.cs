namespace Business.DTOs.Responses
{
    public class CreatedCityResponse
    {
        public Guid Id { get; set; }

        public Guid TownId { get; set; }

        public Guid CountryId { get; set; }

        public string Name { get; set; }
    }
}
