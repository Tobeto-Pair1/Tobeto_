using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class CourseCategory : Entity<int>
{ 
    public int CategoryId { get; set; }


    public int CourseId { get; set; }
    public List<Course> Courses { get; set; }


    public ICollection<Category> Categories { get; set; }

   
  
 


}
