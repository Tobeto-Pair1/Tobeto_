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


        //builder.Property(ul => ul.PositionId).HasColumnName("PositionId").IsRequired();
        //builder.Property(ul => ul.SectorId).HasColumnName("SectorId").IsRequired();
        //builder.Property(ul => ul.CompanyId).HasColumnName("CompanyId").IsRequired();

        //builder.HasOne(b => b.Position).WithMany(b => b.Experiences).HasForeignKey(b => b.PositionId);
        //builder.HasOne(b => b.Sector).WithMany(b => b.Experiences).HasForeignKey(b => b.SectorId);
        //builder.HasOne(b => b.Company).WithMany(b => b.Experiences).HasForeignKey(b => b.CompanyId);
    }
}