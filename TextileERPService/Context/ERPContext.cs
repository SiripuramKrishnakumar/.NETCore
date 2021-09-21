using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TextileERPService.Models;
using TextileERPService.Mappers;

namespace TextileERPService.Context
{
    public class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=constr");
            }
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Fabric> Fabrics { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<UOM> UOMs { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Customer>().ToTable("Customer", "Person");
            modelBuilder.Entity<Fabric>().ToTable("Fabric", "Master");
            modelBuilder.Entity<Country>().ToTable("Country","Master");
            modelBuilder.Entity<UOM>().ToTable("UOM", "Master");
            modelBuilder.Entity<Invoice>().ToTable("Invoice", "Transaction");
            modelBuilder.Entity<InvoiceItem>().ToTable("ÏnvoiceItems", "Transaction");
            modelBuilder.Entity<Bill>().ToTable("Bill", "Payment");

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new BillMap());
            modelBuilder.ApplyConfiguration(new UOMMap());
            modelBuilder.ApplyConfiguration(new FabricMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new InvoiceItemMap());
        }
        

    }
    
}
