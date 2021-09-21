using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;
namespace TextileERPService.Mappers
{
    public class InvoiceItemMap : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(i=>i.ItemId);
            builder.Property(i => i.Amount).IsRequired();
            builder.Property(i => i.FabricId).IsRequired();
            builder.Property(i => i.InvoiceId).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
            builder.HasOne(i => i.Invoice).WithMany(i => i.InvoiceItems);
            builder.HasOne(i => i.Fabric).WithMany(i => i.InvoiceItems);
        }
    }
}
