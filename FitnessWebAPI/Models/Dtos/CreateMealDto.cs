namespace FitnessWebAPI.Models.Dtos
{
    public class CreateMealDto
    {
        public string Name { get; set; } = String.Empty;
        public int Calories { get; set; }
        public int Protein { get; set; }
        public List<CreateMealIngredientDto>? Ingredients { get; set; }
    }
}
