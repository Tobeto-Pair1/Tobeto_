﻿namespace Business.DTOs.Users
{
    public class UpdatedUserResponse
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid AdrressId { get; set; }
    }
}
