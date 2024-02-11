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
    public class AsyncLessonDetailConfiguration : IEntityTypeConfiguration<AsyncLessonDetail>
    {
        public void Configure(EntityTypeBuilder<AsyncLessonDetail> builder)
        {
            builder.ToTable("AsyncLessonDetails").HasKey(b => b.Id);
            builder.Property(b => b.ManufacturerId).HasColumnName("ManufacturerId");
            builder.Property(b => b.AsyncLessonId).HasColumnName("AsyncLessonId");
            builder.Property(b => b.LessonLanguageId).HasColumnName("LessonLanguageId");
            builder.Property(b => b.SubTypeId).HasColumnName("SubTypeId");


            builder.HasOne(b => b.Manufacturer);
            builder.HasOne(b => b.Category);
            builder.HasOne(b => b.AsyncLesson);
            builder.HasOne(b => b.LessonLanguage);
            builder.HasOne(b => b.SubType);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
