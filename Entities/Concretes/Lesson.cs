using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Lesson :Entity<int>
{

    public string Name { get; set; }
    public DateTime DurationTime { get; set; }  //total süre
    public DateTime TimeSpent { get; set; }  //geçirilen süre

    public int CourseModuleId { get; set; }
    public CourseModule CourseModule { get; set; }

    






}
