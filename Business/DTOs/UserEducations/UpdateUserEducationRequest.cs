﻿namespace Business.DTOs.UserEducations
{
    public class UpdateUserEducationRequest
    {
        public string EducationType { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduationDate { get; set; }
    }
}