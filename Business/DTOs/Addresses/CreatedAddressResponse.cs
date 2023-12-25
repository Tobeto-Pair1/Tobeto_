using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Addresses;

public class CreatedAddressResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
    public Guid CountryName { get; set; }
    public Guid CityName { get; set; }
    public Guid TownName { get; set; }
    public string Description { get; set; }
}
