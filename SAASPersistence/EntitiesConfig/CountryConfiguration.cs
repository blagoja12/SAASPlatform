using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAASDomain.Entities;

namespace SAASPersistence.EntitiesConfig
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.CountryCode);
            builder.Property(t =>t.CountryCode).HasMaxLength(50);
            builder.Property(t => t.CountryName).HasMaxLength(50);
            builder.Property(t => t.RegionId);

            builder.HasOne(d => d.Region)
             .WithMany(p => p.Countries)
             .HasForeignKey(d => d.RegionId)
             .OnDelete(DeleteBehavior.NoAction)
             .HasConstraintName("FK_Country_Region");
        }
    }
}
