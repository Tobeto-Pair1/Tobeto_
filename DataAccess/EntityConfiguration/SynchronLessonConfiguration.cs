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
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.SynchronLessonDetailId).HasColumnName("SynchronLessonDetailId");
            builder.Property(b => b.SessionName).HasColumnName("SessionName");
            builder.Property(b => b.TimeSpent).HasColumnName("TimeSpent");
            builder.Property(b => b.StartTime).HasColumnName("StartTime");
            builder.Property(b => b.EndTime).HasColumnName("EndTime");

            builder.HasMany(b => b.SynchronLessonInstructor);
            builder.HasOne(b => b.SynchronLessonDetail);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}