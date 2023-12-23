using System;
using System.Reflection;
using Core.Entities;

namespace Entities.Concretes;

public class AboutOfCourse : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime SpentTime { get; set; }

    public virtual Category Category { get; set; }
    public virtual Manufacturer Manufacturer { get; set; }
    public virtual Course Course { get; set; }

}

