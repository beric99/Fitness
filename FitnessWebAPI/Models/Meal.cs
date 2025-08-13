namespace FitnessWebAPI.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public List<MealIngredients> Ingredients { get; set; } = new();
    }
}
