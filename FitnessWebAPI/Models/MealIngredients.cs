namespace FitnessWebAPI.Models
{
    public class MealIngredients
    {
        public int Id { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public int Amount { get; set; }
    }
}
