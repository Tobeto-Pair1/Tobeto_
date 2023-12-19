using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public  class CourseModule: Entity<int>
{


    public string Name { get; set; }
    public List<Lesson> Lessons { get; set; }




}
