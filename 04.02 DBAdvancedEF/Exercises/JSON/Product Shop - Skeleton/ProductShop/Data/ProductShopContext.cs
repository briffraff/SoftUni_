namespace ProductShop.Data
{
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
            var homePC = "RR-PC\\SQLEXPRESS";
            var workPC = "BG-BORKO\\SQLEXPRESS";

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer($"Server = {homePC}; Database=ProductShop; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId});
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