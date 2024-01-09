using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class ForeignLanguageConfiguration : IEntityTypeConfiguration<ForeignLanguage>
{
    public void Configure(EntityTypeBuilder<ForeignLanguage> builder)
    {
        builder.ToTable("ForeignLanguages").HasKey(b => b.Id);
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(b => b.UserLanguages);
        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}
