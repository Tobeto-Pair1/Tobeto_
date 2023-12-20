using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests;

public class CreateAddressRequest
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
    public string Description { get; set; }
}
