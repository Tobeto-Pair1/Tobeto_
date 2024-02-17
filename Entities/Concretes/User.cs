using Core.Entities;
using Entities.Concrete;


namespace Entities.Concretes;

public class User: Entity<Guid>
{
    public Guid? AddressId { get; set; }
    public Guid? ImageId { get; set; }
    public string  FirstName { get; set; }
    public string  LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime?  BirthDate { get; set; }
    public string? AboutMe { get; set; }


    public virtual  Address Address { get; set; }
    public virtual Image Image { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }
    public virtual ICollection<Certificate> Certificate { get; set; }
    public virtual ICollection<UserEducation> UserEducations { get; set; }
    public virtual ICollection<UserSkill> UserSkills { get; set; }
    public virtual ICollection<UserSocial> UserSocials { get; set; }
    public virtual ICollection<UserLanguage> UserLanguages { get; set; }
 

    //public virtual ICollection<Student>Students { get; set; }
    //public virtual ICollection<Employee>Employees { get; set; }
    //public virtual ICollection<Instructor> Instructors { get; set; }


}
