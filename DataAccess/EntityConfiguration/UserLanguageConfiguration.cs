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
            builder.ToTable("UserLanguages").HasKey(b => b.Id);
            builder.Property(ul => ul.UserId).HasColumnName("Name").IsRequired();
            builder.Property(ul => ul.LevelId).HasColumnName("LanguageLevel");
        
            
            builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
        }
    }
}
