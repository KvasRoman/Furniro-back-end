using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Furniro.DataAccess.Models;

namespace Furniro.DataAccess
{

    public class FurniroDbContext : DbContext
    {
        DbSet<SupportRequest> SupportRequests { get; set; }
        DbSet<Country> Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration config = builder.Build();
            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }

    }
}