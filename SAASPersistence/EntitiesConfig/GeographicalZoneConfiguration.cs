using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAASDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAASPersistence.EntitiesConfig
{
    public class GeographicalZoneConfiguration
    {
        public void Configure(EntityTypeBuilder<GeographicalZone> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name).HasMaxLength(50);

        }
    }
}
