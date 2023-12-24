using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class CourseProgram : Entity<Guid> 
{
    public Guid ProgramId  { get; set; }
    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual Program Program { get; set; }

}
