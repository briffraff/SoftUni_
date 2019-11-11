namespace ProductShop.Data
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                var config = new ConfigApp();

                optionsBuilder.UseSqlServer(config.ConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId);

                entity.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId);
            });
        }
    }
}