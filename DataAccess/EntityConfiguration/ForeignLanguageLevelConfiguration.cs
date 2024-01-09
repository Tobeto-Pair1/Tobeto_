using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class ForeignLanguageLevelConfiguration : IEntityTypeConfiguration<ForeignLanguageLevel>
{
    public void Configure(EntityTypeBuilder<ForeignLanguageLevel> builder)
    {
        builder.ToTable("ForeignLanguageLevels").HasKey(b => b.Id);
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(b => b.UserLanguages);
        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}