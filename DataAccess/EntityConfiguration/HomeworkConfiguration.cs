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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("Homeworks").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CourseId).HasColumnName("CourseId");
            builder.Property(b => b.SynchronLessonId).HasColumnName("SynchronLessonId");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.LastDate).HasColumnName("LastDate");
            builder.Property(b => b.HomeworkTaskFile).HasColumnName("HomeworkTaskFile");
            builder.Property(b => b.HomeworkSentFile).HasColumnName("HomeworkSentFile");

            builder.HasOne(b => b.Course);
            builder.HasOne(b => b.SynchronLesson);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
    }
}
