using Core.Entities;

namespace Entities.Concretes;

public class SynchronLessonDetail : Entity<Guid>
{
    public Guid CourseModuleId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LessonLanguageId { get; set; }
    public Guid SubTypeId { get; set; }
 
    public virtual Category Category { get; set; }
    public virtual CourseModule CourseModule { get; set; }
    public virtual LessonLanguage LessonLanguage { get; set; } 
    public virtual SubType SubType { get; set; }
}

