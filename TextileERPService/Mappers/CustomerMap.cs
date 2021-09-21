using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;

namespace TextileERPService.Mappers
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(i=>i.CustomerId).HasName("Id");
            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Email).HasMaxLength(50).IsRequired();
            builder.Property(i => i.MobileNumber).HasMaxLength(50).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.ModifiedOn).IsRequired();
            builder.Property(i => i.Gender).IsRequired();
            
        }
    }
}
