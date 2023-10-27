using Microsoft.AspNetCore.Mvc;
using ReacipEasy.Models;
using ReacipEasy.Repositories;

namespace ReacipEasy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly RecipesRepository _recipesRepository;
        public RecipesController(RecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipesRepository.GetAll();

            if (recipes != null && recipes.Any())
            {
                return Ok(recipes);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetRecipeById(string id)
        {
            var recipe = await _recipesRepository.GetById(id: id);

            if (recipe != null)
            {
                return Ok(recipe);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(RecipeModel recipe)
        {
            await _recipesRepository.Create(recipe);
            return CreatedAtAction(actionName: nameof(GetAllRecipes), routeValues: new { id = recipe.Id }, value: recipe);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateRecipe(string id, RecipeModel recipe)
        {
            var existingRecipe = await _recipesRepository.GetById(id: id);

            if (existingRecipe is null)
            {
                return BadRequest();
            }

            await _recipesRepository.Update(recipe, id);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            var existingRecipe = await _recipesRepository.GetById(id: id);

            if (existingRecipe is null)
            {
                return BadRequest();
            }

            await _recipesRepository.Delete(id: id);

            return NoContent();
        }
    }
}
