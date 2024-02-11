using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CountryId).HasColumnName("CountryId");          
        builder.Property(b => b.Name).HasColumnName("Name");

        //builder.HasOne(aob => aoc.Account)
        //        .WithMany(a => a.AccountOccupationClasses)
        //        .HasForeignKey(aob => aoc.AccountId);

        builder.HasOne(b => b.Country);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}
