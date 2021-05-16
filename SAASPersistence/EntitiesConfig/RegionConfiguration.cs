using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAASDomain.Entities;

namespace SAASPersistence.EntitiesConfig
{ 
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.Vat).HasPrecision(18, 2);

            builder.HasOne(d => d.GeographicalZone)
             .WithMany(p => p.Regions)
             .HasForeignKey(d => d.GeographicalZoneId)
             .OnDelete(DeleteBehavior.NoAction)
             .HasConstraintName("FK_Region_GeographicalZone");

        }
    }
}
