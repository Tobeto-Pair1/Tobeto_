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
    public class SynchronLessonDetailConfiguration:IEntityTypeConfiguration<SynchronLessonDetail>
    {
        public void Configure(EntityTypeBuilder<SynchronLessonDetail> builder)
        {
            builder.ToTable("SynchronLessonDetails").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Name).HasColumnName("Name");
            builder.Property(s => s.CourseId).HasColumnName("CourseId");
            builder.Property(s => s.CategoryId).HasColumnName("CategoryId");
            builder.Property(s => s.LessonLanguageId).HasColumnName("LessonLanguageId");
           
           
            builder.HasOne(s => s.Category);
            builder.HasOne(s => s.Course);
            builder.HasOne(s => s.SubType);
            builder.HasOne(s => s.LessonLanguage);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
