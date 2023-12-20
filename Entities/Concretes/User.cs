using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concretes;

public class User: Entity<Guid>
{
    public string IdentityNumber { get; set; }
    public string  FirstName { get; set; }
    public string  Lastname { get; set; }
    public string  PhoneNumber { get; set; }
    public string?  Email { get; set; }
    public DateTime  BirthDate { get; set; }
    public Guid AdrressId { get; set; }


    public virtual Address Address { get; set; }
    public virtual ICollection<UserSkill> UserSkills { get; set; }
    public virtual ICollection<UserSocial> UserSocials { get; set; }
    public virtual ICollection<Student>Students { get; set; }
    public virtual ICollection<Employee>Employees { get; set; }
    public virtual ICollection<Instructor> Instructors { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }


}
