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
            builder.ToTable("SynchronLessonDetails").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.CourseId).HasColumnName("CourseId");
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
            builder.Property(b => b.LessonLanguageId).HasColumnName("LessonLanguageId");
           
           
            builder.HasOne(b => b.Category);
            builder.HasOne(b => b.Course);
            builder.HasOne(b => b.SubType);
            builder.HasOne(b => b.LessonLanguage);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
