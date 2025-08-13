using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealIngredients> MealIngredients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
