﻿namespace Business.DTOs.Cities;

public class UpdatedCityResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
}
