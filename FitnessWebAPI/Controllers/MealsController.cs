using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessWebAPI.Data;
using FitnessWebAPI.Models;
using FitnessWebAPI.Models.Dtos;

namespace FitnessWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MealsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealDto>>> GetMeal()
        {
            return await _context.Meals.Select(m => new MealDto
            {
                Id = m.Id,
                Name = m.Name,
                Calories = m.Calories,
                Protein = m.Protein,
                Ingredients = m.Ingredients.Select(i => new MealIngredientDto
                {
                    IngredientId = i.IngredientId,
                    Amount = i.Amount,
                }).ToList()

            }).ToListAsync();
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealDto>> GetMeal(int id)
        {
            var meal = await _context.Meals.Select(m => new MealDto
            {
                Id = m.Id,
                Name = m.Name,
                Calories = m.Calories,
                Protein = m.Protein,
                Ingredients = m.Ingredients.Select(i => new MealIngredientDto
                {
                    IngredientId = i.IngredientId,
                    Amount = i.Amount,
                }).ToList()

            }).FirstAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // POST: api/Meals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealDto>> PostMeal(MealDto mealDto)
        {
            var meal = new Meal()
            {
                Id = mealDto.Id,
                Name = mealDto.Name,
                Calories = mealDto.Calories,
                Protein = mealDto.Protein,
                Ingredients = mealDto.Ingredients.Select(i => new MealIngredients()
                {
                    MealId = mealDto.Id,
                    IngredientId = i.IngredientId,
                    Amount = i.Amount,
                }).ToList()
            };

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, MealDto mealDto)
        {
            if (id != mealDto.Id)
            {
                return BadRequest();
            }

            var existingMeal = await _context.Meals
                .Include(m => m.Ingredients)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (existingMeal == null)
            {
                return NotFound();
            }

            existingMeal.Name = mealDto.Name;
            existingMeal.Calories = mealDto.Calories;
            existingMeal.Protein = mealDto.Protein;

            foreach (var ingredient in mealDto.Ingredients)
            {
                var existingIngredient = existingMeal.Ingredients.FirstOrDefault(i => i.Id == ingredient.IngredientId);
                if (existingIngredient == null)
                {
                    existingMeal.Ingredients.Add(new MealIngredients
                    {
                        MealId = id,
                        IngredientId = ingredient.IngredientId,
                        Amount = ingredient.Amount
                    });
                }
                else
                {
                    existingIngredient.Amount = ingredient.Amount;
                }
                
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
