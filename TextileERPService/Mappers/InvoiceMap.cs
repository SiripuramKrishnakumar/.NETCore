using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;

namespace TextileERPService.Mappers
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i=>i.InvoiceId).HasName("Id");
            builder.Property(i => i.InvoiceNumber).IsRequired().HasMaxLength(10);
            builder.Property(i => i.Narration).HasMaxLength(100);
            builder.Property(i => i.CustomerId).IsRequired();
            builder.Property(i => i.TotalAmount).IsRequired();
            builder.Property(i => i.PaidAmount).IsRequired();
            builder.Property(i => i.IsPaid).IsRequired();
            builder.Property(i => i.IsPartialPaid).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
            builder.Property(i => i.IsLocked).IsRequired();
            builder.HasOne(i => i.Customer).WithMany(i=>i.Invoice);
            
        }
    }
}
