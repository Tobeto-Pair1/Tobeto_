using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Instructors;

public class CreateInstructorRequest
{
    public Guid? ImageId { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? AboutMe { get; set; }
    public Guid UserId { get; set; }
}
