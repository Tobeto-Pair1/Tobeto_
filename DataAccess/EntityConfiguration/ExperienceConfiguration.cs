using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences").HasKey(b => b.Id);
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ul => ul.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(ul => ul.PositionName).HasColumnName("PositionName").IsRequired();
        builder.Property(ul => ul.SectorName).HasColumnName("SectorName").IsRequired();
        builder.Property(ul => ul.CompanyName).HasColumnName("CompanyName").IsRequired();


        builder.HasOne(b => b.User);
        builder.HasOne(b => b.City);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}