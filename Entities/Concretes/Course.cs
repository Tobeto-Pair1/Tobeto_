using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Course : Entity<int>
{

    public string Name { get; set; }
     
    public bool IsCourseType { get; set; }
    public virtual ICollection<CourseProgram> CoursePrograms { get; set; }



 // public List<CourseCategory> CourseCategories { get; set; }

}

