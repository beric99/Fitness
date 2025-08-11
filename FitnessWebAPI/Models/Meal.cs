namespace FitnessWebAPI.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Calories { get; set; }
        public int Protein { get; set; }
    }
}
