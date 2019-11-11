using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {

        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var homePC = "RR-PC\\SQLEXPRESS";
            var workPC = "BG-BORKO\\SQLEXPRESS";

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer($"Server = {workPC}; Database=CarDealer; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new {k.PartId, k.CarId });
            });
        }
    }
}
