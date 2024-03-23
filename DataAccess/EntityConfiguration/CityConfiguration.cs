using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CountryId).HasColumnName("CountryId");          
        builder.Property(b => b.Name).HasColumnName("Name");

        string countryId = "dbe7b4e6-e5d0-ee11-8a30-ca2125e0033b";
        string kocaeliId = "badc6275-ebd0-ee11-8a30-ca2125e0033b";
        string istanbulId = "c1dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string ankaraId = "dddc6275-ebd0-ee11-8a30-ca2125e0033b";

        string malatyaId = "b7dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string tranbzonId = "a6dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string sakaryaId = "addc6275-ebd0-ee11-8a30-ca2125e0033b";

        builder.HasData(new City { Id = Guid.Parse(kocaeliId), CountryId = Guid.Parse(countryId), Name = "Kocaeli" });
        builder.HasData(new City { Id = Guid.Parse(istanbulId), CountryId = Guid.Parse(countryId), Name = "İstanbul" });
        builder.HasData(new City { Id = Guid.Parse(ankaraId), CountryId = Guid.Parse(countryId), Name = "Ankara" });

        builder.HasData(new City { Id = Guid.Parse(malatyaId), CountryId = Guid.Parse(countryId), Name = "Malatya" });
        builder.HasData(new City { Id = Guid.Parse(sakaryaId), CountryId = Guid.Parse(countryId), Name = "Sakarya" });
        builder.HasData(new City { Id = Guid.Parse(tranbzonId), CountryId = Guid.Parse(countryId), Name = "Trabzon" });


        builder.HasOne(b => b.Country);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}
