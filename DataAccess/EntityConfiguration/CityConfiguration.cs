﻿using Entities.Concretes;
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
        builder.ToTable("Cities").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CountryId).HasColumnName("CountryId");          
        builder.Property(c => c.Name).HasColumnName("Name");

        //builder.HasOne(aoc => aoc.Account)
        //        .WithMany(a => a.AccountOccupationClasses)
        //        .HasForeignKey(aoc => aoc.AccountId);

        builder.HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c=>c.CountryId);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}
