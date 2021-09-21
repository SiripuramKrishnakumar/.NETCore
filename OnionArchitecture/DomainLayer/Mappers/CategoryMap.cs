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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.HasKey(i => i.CategoryId);
            modelBuilder.Property(i => i.Name).IsRequired().HasMaxLength(70);
            modelBuilder.Property(i => i.CreatedOn).IsRequired();
            modelBuilder.Property(i => i.ModifiedOn).IsRequired();
        }
    }
}
