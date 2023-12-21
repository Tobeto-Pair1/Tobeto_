using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.EntityConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(b => b.Id);
        builder.Property(b => b.Id ).HasColumnName("Id").IsRequired(); 
        builder.Property(b => b.CityId).HasColumnName("CityId");
        builder.Property(b => b.CountryId).HasColumnName("CountryId"); 
        builder.Property(b => b.TownId).HasColumnName("TownId"); 
        builder.Property(b => b.Description).HasColumnName("Description");



        builder.HasOne(b => b.City);
        builder.HasOne(b => b.Country);
        builder.HasOne(b => b.Town);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
