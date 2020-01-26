using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<DailyStock> DailyStocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MaterialStock> MaterialStocks {get; set;}
        public DbSet<DailyMaterialUse> DailyMaterialsUsed {get; set;}
        public DbSet<Sale> Sales {get; set;}
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProfitLoss> ProfitLosses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Product>().HasMany(x=>x.DailyStocks).WithOne(y=>y.Product);
            //builder.Entity<Customer>().HasMany(x=>x.Payments).WithOne(y=>y.Customer);
            base.OnModelCreating(builder);
        }



    }
}
