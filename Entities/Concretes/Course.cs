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

    public int AboutOfCourseId { get; set; }
    public AboutOfCourse AboutOfCourse { get; set; }
    public  List<CourseModule> CourseModules { get; set; }




}

