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
    public class SynchronLessonInstructorConfiguration : IEntityTypeConfiguration<SynchronLessonInstructor>
    {
        public void Configure(EntityTypeBuilder<SynchronLessonInstructor> builder)
        {
            builder.ToTable("SynchronLessonInstructors").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId").IsRequired();


            builder.HasOne(b => b.Instructor);
            builder.HasOne(b => b.SynchronLesson);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
