using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Cities;

public class CreateCityRequest
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }

}
