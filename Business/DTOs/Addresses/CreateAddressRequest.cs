using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Addresses;

public class CreateAddressRequest
{
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string TownName { get; set; }
    public string Description { get; set; }

}
