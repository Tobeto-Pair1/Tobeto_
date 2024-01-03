using System;

namespace Business.DTOs.Towns
{
    public class UpdatedTownResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}

