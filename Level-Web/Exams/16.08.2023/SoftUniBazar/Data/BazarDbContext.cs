using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AdBuyer> AdsBuyers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Ads)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdBuyer>()
                .HasKey(x => new
                {
                    x.BuyerId,
                    x.AdId
                });

            modelBuilder.Entity<AdBuyer>()
                .HasOne(x => x.Buyer)
                .WithMany()
                .HasForeignKey(x => x.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdBuyer>()
                .HasOne(x => x.Ad)
                .WithMany()
                .HasForeignKey(x => x.AdId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}