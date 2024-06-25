using Microsoft.EntityFrameworkCore;
using SaleKiosk.Domain.Models;

namespace SaleKiosk.Infrastructure
{
    public class FoodWarehouseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public FoodWarehouseDbContext(DbContextOptions<FoodWarehouseDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Supplier and Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}
