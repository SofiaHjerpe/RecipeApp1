using Microsoft.AspNetCore.Mvc;
using Database;


namespace Recipe.Controllers
{
    public class RecipesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Mongodb db = new Mongodb(); 
            List<RecipeClass> recipes = await db.GetAllRecipes();


            return View(recipes);
        }

        public async Task<IActionResult> Details(string id)
        {
            Mongodb db = new Mongodb();
            RecipeClass recipe = await db.GetRecipeById(id);  
            return View(recipe);    
        }

        public async Task<IActionResult> Delete(string id)
        {
            Mongodb db = new Mongodb();
            var recipe = await db.GetRecipeById(id);
            return View(recipe);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            Mongodb db = new Mongodb();
            await db.DeleteRecipe(id);
            return Redirect("/Recipes");

        }
    }
}
