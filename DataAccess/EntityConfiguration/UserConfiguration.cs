using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("Users").HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnName("Id");
        builder.Property(o => o.AddressId).HasColumnName("AddressId");
        builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(b => b.Lastname).HasColumnName("Lastname").IsRequired();
        builder.Property(o => o.IdentityNumber).HasColumnName("IdentityNumber").IsRequired();
        builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(b => b.Email).HasColumnName("Email");
        builder.Property(b => b.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(b => b.AboutMe).HasColumnName("AboutMe").IsRequired();

        builder.HasIndex(indexExpression: b => b.IdentityNumber, name: "UK_Users_IdentityNumber").IsUnique();

        builder.HasOne(b=>b.Address);

        builder.HasMany(b => b.UserLanguages);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);











    }
}
