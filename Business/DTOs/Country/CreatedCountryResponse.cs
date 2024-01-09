using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Country
{
    public class CreatedCountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? CityId { get; set; }
    }
}
