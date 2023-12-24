using Entities.Concrete;
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
    public class UserLanguageConfiguration: IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        {
            builder.ToTable("UserLanguages").HasKey(b => new { b.Id, b.ForeignLanguageId, b.LanguageLevelId });
            builder.Property(ul => ul.Id).HasColumnName("UserId").IsRequired();
            builder.Property(ul => ul.ForeignLanguageId).HasColumnName("ForeignLanguageId").IsRequired();
            builder.Property(ul => ul.LanguageLevelId).HasColumnName("LanguageLevelId").IsRequired();

            builder.HasOne(b => b.ForeignLanguage).WithMany(b => b.Users).HasForeignKey(b => b.ForeignLanguageId);
            builder.HasOne(b => b.User).WithMany(b => b.UserLanguages).HasForeignKey(b => b.Id);
            builder.HasOne(b => b.LanguageLevel).WithMany(b => b.UserLanguages).HasForeignKey(b => b.LanguageLevelId);
            builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
        }
    }
}
