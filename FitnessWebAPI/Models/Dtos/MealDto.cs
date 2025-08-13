namespace FitnessWebAPI.Models.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Calories { get; set; }
        public int Protein { get; set; }
        public List<MealIngredientDto> Ingredients { get; set; } = new();
    }
}
