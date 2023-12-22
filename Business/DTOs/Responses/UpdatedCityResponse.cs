namespace Business.DTOs.Responses
{
    public class UpdatedCityResponse
    {
        public Guid Id { get; set; }

        public Guid TownId { get; set; }

        public Guid CountryId { get; set; }

        public string Name { get; set; }
    }
}
