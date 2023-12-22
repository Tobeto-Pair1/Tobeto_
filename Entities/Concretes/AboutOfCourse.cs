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

    public Category Category { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public Course Course { get; set; }
   // public Lesson Lesson { get; set; }

}

