using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class SynchronLessonConfiguration : IEntityTypeConfiguration<SynchronLesson>
    {
        public void Configure(EntityTypeBuilder<SynchronLesson> builder)
        {
            builder.ToTable("SynchronLessons").HasKey(b => b.Id);
            builder.Property(b => b.DurationTime).HasColumnName("DurationTime").IsRequired();
            builder.Property(b => b.TimeSpent).HasColumnName("TimeSpent");
            builder.Property(b => b.StartTime).HasColumnName("StartTime");
            builder.Property(b => b.EndTime).HasColumnName("EndTime");
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId");

            builder.HasOne(b => b.Instructors);
            builder.HasOne(b => b.CourseType);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


        }
    }
}
