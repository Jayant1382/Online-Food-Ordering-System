using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.MenuMicroservice.DataAccessLayer
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Menu entity
            modelBuilder.Entity<Menu>().HasKey(m => m.Id);
            modelBuilder.Entity<Menu>().Property(m => m.Name).IsRequired();
            modelBuilder.Entity<Menu>().Property(m => m.Price).IsRequired();
        }
    }
}
