using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class AsyncLessonConfiguration :IEntityTypeConfiguration<AsyncLesson>
    {

    public void Configure(EntityTypeBuilder<AsyncLesson> builder)
        {
            builder.ToTable("AsyncLessons").HasKey(b => b.Id);
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.DurationTime).HasColumnName("DurationTime");
            builder.Property(b => b.TimeSpent).HasColumnName("TimeSpent");
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId");
            builder.Property(b => b.CourseModuleId).HasColumnName("CourseModuleId");


            builder.HasOne(b => b.Instructor);
            builder.HasOne(b => b.CourseModule);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}