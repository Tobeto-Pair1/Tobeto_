﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses;

public class GetListAddressResponse
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; }
    public int TownId { get; set; }
    public string TownName { get; set; }
    public string Description { get; set; }
}
