using Core.Entities;

namespace Entities.Concretes;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CourseTypeId { get; set; }
    public Guid? ImageId { get; set; }


    public virtual Image Image { get; set; }
    public virtual CourseType CourseType { get; set; }
    public virtual AboutOfCourse AboutOfCourse { get; set; }
    public virtual ICollection<CourseModule> CourseModules { get; set; }
    public virtual ICollection<CourseProgram> CoursePrograms { get; set; }
}

