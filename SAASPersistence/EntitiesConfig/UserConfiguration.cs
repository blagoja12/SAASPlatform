using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAASDomain.Entities;

namespace SAASPersistence.EntitiesConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(255);
            builder.Property(t => t.CountryCode).HasMaxLength(50);

            builder.HasOne(d => d.Country)
            .WithMany(p => p.Users)
            .HasForeignKey(d => d.CountryCode)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_User_Country");
        }
    }
}
