using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name");

            string id = "dbe7b4e6-e5d0-ee11-8a30-ca2125e0033b";
            builder.HasData(new Country { Id = Guid.Parse(id), Name = "Türkiye" });


            builder.HasMany(c => c.Cities);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
