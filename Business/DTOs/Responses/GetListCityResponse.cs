using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class GetListCityResponse
    {
        public Guid Id { get; set; }

        public Guid TownId { get; set; }

        public Guid CountryId { get; set; }

        public string Name { get; set; }
    }
}
