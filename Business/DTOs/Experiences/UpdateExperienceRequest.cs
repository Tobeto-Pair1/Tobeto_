﻿namespace Business.DTOs.Experiences;

public class UpdateExperienceRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string CompanyName { get; set; }
    public string PositionName { get; set; }
    public string SectorName { get; set; }
    public Guid CityId { get; set; }
    public DateTime JobStart { get; set; }
    public DateTime JobCompletion { get; set; }
    public string Description { get; set; }
}
