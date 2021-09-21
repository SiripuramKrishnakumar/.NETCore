using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;

namespace TextileERPService.Mappers
{
    public class BillMap : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(i=>i.BillId).HasName("Id");
            builder.Property(i => i.BillNumber).HasMaxLength(10).IsRequired();
            builder.Property(i => i.InvoiceAmount).IsRequired();
            builder.Property(i => i.DiscPerc).IsRequired();
            builder.Property(i => i.DiscAmount).IsRequired();
            builder.Property(i => i.ActualAmount).IsRequired();
            builder.Property(i => i.PaidAmount).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
            builder.HasOne(i => i.Invoice).WithOne(i=>i.Bill);
        }
    }
}
