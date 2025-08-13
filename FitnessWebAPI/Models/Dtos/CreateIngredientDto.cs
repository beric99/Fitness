using FitnessWebAPI.Data;

namespace FitnessWebAPI.Models.Dtos
{
    public class CreateIngredientDto
    {
        public string Name { get; set; } = string.Empty;
        public MeasurementUnit Unit { get; set; }
        public int UnitAmount { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
    }
}
