using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;

public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
{
    public void Configure(EntityTypeBuilder<UserLanguage> builder)
    {
        builder.ToTable("UserLanguages").HasKey(b => new { b.Id, b.UserId, b.ForeignLanguageId, b.ForeignLanguageLevelId });
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(b => b.ForeignLanguageId).HasColumnName("ForeignLanguageId").IsRequired();
        builder.Property(b => b.ForeignLanguageLevelId).HasColumnName("LanguageLevelId").IsRequired();

        builder.HasOne(b => b.ForeignLanguage);
        builder.HasOne(b => b.User);
        builder.HasOne(b => b.ForeignLanguageLevel);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
