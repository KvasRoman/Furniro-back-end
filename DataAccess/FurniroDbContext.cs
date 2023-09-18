using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Furniro.DataAccess.Models.DataAccess;
using Furniro.DataAccess.Models.DataAccess.Properties;

namespace Furniro.DataAccess
{

    public class FurniroDbContext : DbContext
    {
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<SupportRequest> SupportRequests { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<EmailSubscriber> EmailSubscribers { get; set; }
        DbSet<SeatProperties> SeatProperties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImages)
                .WithOne(e => e.ProductRef)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder.Entity<SeatProperties>()
                .HasOne(e => e.Product)
                .WithOne(e => e.SeatProperties)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration config = builder.Build();
            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }

    }
}