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

        builder.ToTable("User").HasKey(o => o.Id);

        builder.Property(o => o.AdrressId).HasColumnName("AdrressId").IsRequired();
        builder.Property(o => o.IdentityNumber).HasColumnName("IdentityNumber").IsRequired();
        builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(b => b.Lastname).HasColumnName("Lastname").IsRequired();
        builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(b => b.Email).HasColumnName("Email");
        builder.Property(b => b.BirthDate).HasColumnName("BirthDate");


        builder.HasOne("Address");


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);











    }
}
