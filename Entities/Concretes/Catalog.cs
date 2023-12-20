using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Catalog : Entity<Guid>
{

    public Guid SituationId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid InstructorId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LevelId { get; set; }


    public Instructor Instructor { get; set; } 
    public Situation Situation { get; set; }
    public SoftwareLanguage SoftwareLanguage { get; set; }
    public Subject Subject { get; set; }
    public Category Category { get; set; }
    public Level Level { get; set; }


}
