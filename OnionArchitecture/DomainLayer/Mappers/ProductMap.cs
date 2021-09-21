using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainLayer.Models;

namespace DomainLayer.Mappers
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> modelBuilder)
        {
            modelBuilder.HasKey(i => i.ProductId);
            modelBuilder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Property(i => i.Description).HasMaxLength(512);
            modelBuilder.Property(i => i.Brand).IsRequired();
            modelBuilder.Property(i => i.Price).IsRequired();
            modelBuilder.Property(i => i.CreatedOn).IsRequired();
            modelBuilder.Property(i => i.ModifiedOn).IsRequired();
            modelBuilder.HasOne(i => i.Category).WithMany(j => j.Products);
        }
    }
}
