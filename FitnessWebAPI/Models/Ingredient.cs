using FitnessWebAPI.Data;

namespace FitnessWebAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public MeasurementUnit Unit { get; set; }   
        public int UnitAmount { get; set; }
        public int Calories { get; set; } 
        public int Protein {  get; set; }
    }
}
