using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FitnessWebAPI.Models.Meal> Meal { get; set; } = default!;

    }
}
