using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Catalog : Entity<int>
{

    public int SituationId { get; set; }
    public int SoftwareLanguageId { get; set; }
    public int InstructorId { get; set; }
    public int SubjectId { get; set; }
    public int CategoryId { get; set; }
    public int LevelId { get; set; }
    public Instructor Instructor { get; set; } 
    public Situation Situation { get; set; }

}
