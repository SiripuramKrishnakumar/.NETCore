using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;

namespace TextileERPService.Mappers
{
    public class FabricMap:IEntityTypeConfiguration<Fabric>
    {
        public void Configure(EntityTypeBuilder<Fabric> builder)
        {
            builder.HasKey(i => i.FabricId);
            builder.Property(i => i.FabricName).HasColumnName("Description");
            builder.Property(i => i.COM).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
            builder.Property(i => i.UOMId).IsRequired();
            builder.HasOne(i => i.UOM).WithOne(i=>i.Fabric);
            builder.HasOne(i => i.Country).WithMany(i=>i.Fabric);
        }
    }
}
