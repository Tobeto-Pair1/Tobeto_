using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class CourseProgram : Entity<int> 
{
    public int ProgramId  { get; set; }
    public int CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual Program Program { get; set; }

}
