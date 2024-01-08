using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
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


    public string GetName()
    {

        return (string.Join(" ", FirstName + Lastname));

    }

}
