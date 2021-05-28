using Domain;
using Domain.CustomerAggregate;
using Domain.OrderAggregate;
using Domain.OrderProductAggregate;
using Domain.ProductAggregate;
using Domain.ProductMetaDataAggregate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMetaData> ProductMetaData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(bc => new { bc.OrderId, bc.ProductId });
            modelBuilder.Entity<OrderProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.OrderProducts)
                .HasForeignKey(bc => bc.ProductId);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(bc => bc.Order)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(bc => bc.OrderId);
        }
    }
}
