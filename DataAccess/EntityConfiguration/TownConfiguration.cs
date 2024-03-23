using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class TownConfiguration : IEntityTypeConfiguration<Town>
{
    public void Configure(EntityTypeBuilder<Town> builder)
    {
        builder.ToTable("Towns").HasKey(b => b.Id);
        builder.Property(b => b.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

        string kocaeliId = "badc6275-ebd0-ee11-8a30-ca2125e0033b";
        string istanbulId = "c1dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string ankaraId = "dddc6275-ebd0-ee11-8a30-ca2125e0033b";

        string malatyaId = "b7dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string tranbzonId = "a6dc6275-ebd0-ee11-8a30-ca2125e0033b";
        string sakaryaId = "addc6275-ebd0-ee11-8a30-ca2125e0033b";

        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "BAŞİSKELE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "İZMİT" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "KARAMÜRSEL" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "GEBZE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "ÇAYIROVA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "DARICA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "DERİNCE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(kocaeliId), Name = "GÖLCÜK" });


        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "SULTANBEYLİ" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "KARTAL" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "SANCAKTEPE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "ESENYURT" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "GÜNGÖREN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "FATİH" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "EYÜP" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(istanbulId), Name = "PENDİK" });


        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "MAMAK" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "NALLIHAN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "KAZAN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "HAYMANA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "ETİMESGUT" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "ÇANKAYA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "BEYPAZARI" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(ankaraId), Name = "AYAŞ" });

        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "DARENDE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "DOĞANŞEHİR" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "ARGUVAN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "HEKİMHAN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "KALE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "PÜTÜRGE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "YEŞİLYURT" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(malatyaId), Name = "KULUNCAK" });

        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "MAÇKA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "SÜRMENE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "OF" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "SÜRMENE" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "DÜZKÖY" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "DERNEKPAZARI" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "TRABZON" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(tranbzonId), Name = "YOMRA" });

        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "SERDİVAN" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "SÖĞÜTLÜ" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "TARAKLI" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "SAPANCA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "PAMUKOVA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "KOCAALİ" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "KAYNARCA" });
        builder.HasData(new Town { Id = Guid.NewGuid(), CityId = Guid.Parse(sakaryaId), Name = "KARASU" });

        builder.HasOne(t => t.City).WithMany(t=>t.Towns).HasForeignKey(b => b.CityId);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
