﻿namespace Business.DTOs.UserSkills;

public class CreatedUserSkillResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SkillId { get; set; }
}
