using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;
namespace TextileERPService.Mappers
{
    public class UOMMap:IEntityTypeConfiguration<UOM>
    {
        public void Configure(EntityTypeBuilder<UOM> builder)
        {
            builder.HasKey(i=>i.UnitId).HasName("Id");
            builder.Property(i => i.Description).IsRequired().HasMaxLength(50);
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
        }
    }
}
