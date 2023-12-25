using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Addresses;

public class GetListAddressResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public Guid TownId { get; set; }
    public string TownName { get; set; }
    public string Description { get; set; }
}
