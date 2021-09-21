using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TextileERPService.Models;

namespace TextileERPService.Mappers
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.CountryName).HasColumnName("Description").IsRequired().HasMaxLength(70);
           
        }
    }
}
