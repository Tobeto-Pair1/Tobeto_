using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class SynchronLessonDetailConfiguration:IEntityTypeConfiguration<SynchronLessonDetail>
{
    public void Configure(EntityTypeBuilder<SynchronLessonDetail> builder)
    {
        builder.ToTable("SynchronLessonDetails").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CourseModuleId).HasColumnName("CourseModuleId");
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
        builder.Property(b => b.LessonLanguageId).HasColumnName("LessonLanguageId");
       
       
        builder.HasOne(b => b.Category);
        builder.HasOne(b => b.CourseModule);
        builder.HasOne(b => b.SubType);
        builder.HasOne(b => b.LessonLanguage);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
