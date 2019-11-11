

namespace Panda.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class PandaDBExtended : IdentityDbContext<PandaUser,PandaUserRole,string>
    {
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }

        public PandaDBExtended()
        {

        }

        public PandaDBExtended(DbContextOptions<PandaDBExtended> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(PandaDbSettings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PandaUser>()
                .HasKey(x => x.Id);

            builder.Entity<Package>()
                .HasKey(package => package.Id);

            builder.Entity<Receipt>()
                .HasKey(package => package.Id);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Packages)
                .WithOne(package => package.Recipient)
                .HasForeignKey(package => package.RecipientId);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Receipts)
                .WithOne(receipt => receipt.Recipient)
                .HasForeignKey(receipt => receipt.RecipientId);

            builder.Entity<Package>()
                .HasOne(x => x.Recipient);

            builder.Entity<Receipt>()
                .HasOne(receipt => receipt.Package)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
