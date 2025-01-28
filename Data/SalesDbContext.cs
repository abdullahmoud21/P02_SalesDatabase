using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Data
{
    internal class SalesDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=ABDULLAH;Intitial Catalog:SalesDB ;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(e => e.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(e => e.Name).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Customer>().Property(e => e.Email).HasColumnType("varchar(80)");
            modelBuilder.Entity<Store>().Property(e => e.Name).HasColumnType("nvarchar(80)");
            modelBuilder.Entity<Product>().Property(e => e.Description).HasColumnType("varchar(250)");
            modelBuilder.Entity<Sale>().Property(e => e.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
