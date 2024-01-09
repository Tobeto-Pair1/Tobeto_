using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concretes;

public class User: Entity<Guid>
{
    public string  FirstName { get; set; }
    public string  Lastname { get; set; }
    public string IdentityNumber { get; set; }
    public string  PhoneNumber { get; set; }
    public string?  Email { get; set; }
    public DateTime  BirthDate { get; set; }
    public Guid AddressId { get; set; }
    public string AboutMe { get; set; }


    public virtual  Address Address { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }
    public virtual ICollection<Certificate> Certificate { get; set; }
    public virtual ICollection<UserEducation> UserEducations { get; set; }
    public virtual ICollection<UserSkill> UserSkills { get; set; }
    public virtual ICollection<UserSocial> UserSocials { get; set; }
    public virtual ICollection<UserLanguage> UserLanguages { get; set; }

    //public virtual ICollection<Student>Students { get; set; }
    //public virtual ICollection<Employee>Employees { get; set; }
    //public virtual ICollection<Instructor> Instructors { get; set; }

    public User()
    {
        Experiences = new HashSet<Experience>();
        Certificate = new HashSet<Certificate>();
        UserEducations = new HashSet<UserEducation>();
        UserSkills = new HashSet<UserSkill>();
        UserSocials = new HashSet<UserSocial>();
        UserLanguages = new HashSet<UserLanguage>();
    }

    public User(string firstName, string lastname, string ıdentityNumber, string phoneNumber, string? email, DateTime birthDate, Guid addressId, string aboutMe) : this()
    {
        FirstName = firstName;
        Lastname = lastname;
        IdentityNumber = ıdentityNumber;
        PhoneNumber = phoneNumber;
        Email = email;
        BirthDate = birthDate;
        AddressId = addressId;
        AboutMe = aboutMe;
    }
}
