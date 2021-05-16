using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAASDomain.Entities;

namespace SAASPersistence.EntitiesConfig
{
    public class SubscriptionPackageConfiguration : IEntityTypeConfiguration<SubscriptionPackage>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPackage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.MonthlyPrice).HasPrecision(18,2);
            builder.Property(t => t.YearlyPrice).HasPrecision(18, 2);
            builder.Property(t => t.GeographicalZoneId);

            builder.HasOne(d => d.GeographicalZone)
              .WithMany(p => p.SubscriptionPackages)
              .HasForeignKey(d => d.GeographicalZoneId)
              .OnDelete(DeleteBehavior.NoAction)
              .HasConstraintName("FK_SubscriptionPackages_Region");

          
        }
    }
}
