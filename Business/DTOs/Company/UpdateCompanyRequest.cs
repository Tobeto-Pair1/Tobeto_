﻿using Entities.Concretes;

namespace Business.DTOs.Company
{
    public class UpdateCompanyRequest
    {
        public string Name { get; set; }

        public Guid ExperienceId { get; set; }
    }
}
