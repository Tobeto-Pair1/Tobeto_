﻿namespace Business.DTOs.UserEducations;

public class UpdatedUserEducationResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string EducationType { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }
}
