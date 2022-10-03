using InnowisePilotApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InnowisePilotApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Fridge> Fridge { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
    }
}
