using System;
using Core.Entities;

namespace Entities.Concretes;

public class Employee : Entity<Guid>
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
    public Guid? DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}





