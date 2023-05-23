using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer;

namespace OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Order entity
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.UserId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.MenuItemId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2).IsRequired();
        }
        }
}



