using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class LessonLanguageConfiguration : IEntityTypeConfiguration<LessonLanguage>
{
    public void Configure(EntityTypeBuilder<LessonLanguage> builder)
    {
        builder.ToTable("LessonLanguages").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(b => b.AsyncLessonDetails);
        builder.HasMany(b => b.SynchronLessonDetails);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}