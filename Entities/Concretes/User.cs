using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concretes;

public class User: Entity<int>
{
    public string IdentityNumber { get; set; }
    public string  FirstName { get; set; }
    public string  Lastname { get; set; }
    public string  PhoneNumber { get; set; }
    public string?  Email { get; set; }
    public DateTime  BirthDate { get; set; }
    public int? AdrressId { get; set; }
    public virtual Address Adrress { get; set; }
    public ICollection<UserSkill> UserSkills { get; set; }
    public ICollection<UserSocial> UserSocials { get; set; }
    public ICollection<Student>Students { get; set; }
    public ICollection<Employee>Employees { get; set; }
    public ICollection<Instructor> Instructors { get; set; }





}
