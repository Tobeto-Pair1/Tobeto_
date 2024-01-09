using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Catalog : Entity<Guid>
{
    //public Guid SituationId { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CategoryId { get; set; }
    //public Guid CourseLevelId { get; set; }


    public Instructor Instructor { get; set; }
    //  public Situation Situation { get; set; }
    public Category Category { get; set; }
    //public CourseLevel Level { get; set; }
}
