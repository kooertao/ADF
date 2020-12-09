using ADF.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADF.Core.Data
{
    /// <summary>
    /// EF Core steps
    /// 1 Create/Modify domain model
    /// 2 Create migration file
    /// 3 Apply the migration file to Database or generate sql scripts
    /// 
    /// Nuget package
    /// 1 Microsoft.EntityFrameworkCore.SqlServer
    /// 2 Microsoft.EntityFrameworkCore.Tool(For migration)
    /// 3 Execute migration commands in Package manage console
    /// (Add-Migration Drop-Database
        //Get-DbContext
        //Remove-Migration
        //Scaffold-DbContext
        //Script-DbContext
        //Script-Migration
        //Update-Database)
    ///  3.1 Add-migration ADFinitial
    ///  3.2 script-migration(sql scripts)/Update-Database -verbose
    /// </summary>
    public class ADFDbContext : DbContext
    {
        public string CurrentUserId { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        public ADFDbContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";

            builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().HasIndex(c => c.Name);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

            builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<ProductCategory>().ToTable($"App{nameof(this.ProductCategories)}");

            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Product>().HasIndex(p => p.Name);
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            builder.Entity<Product>().ToTable($"App{nameof(this.Products)}");
            builder.Entity<Product>().Property(p => p.BuyingPrice).HasColumnType(priceDecimalType);
            builder.Entity<Product>().Property(p => p.SellingPrice).HasColumnType(priceDecimalType);

            builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            builder.Entity<Order>().ToTable($"App{nameof(this.Orders)}");
            builder.Entity<Order>().Property(p => p.Discount).HasColumnType(priceDecimalType);

            builder.Entity<OrderDetail>().ToTable($"App{nameof(this.OrderDetails)}");
            builder.Entity<OrderDetail>().Property(p => p.UnitPrice).HasColumnType(priceDecimalType);
            builder.Entity<OrderDetail>().Property(p => p.Discount).HasColumnType(priceDecimalType);
        }
    }
}
