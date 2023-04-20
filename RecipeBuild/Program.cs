// See https://aka.ms/new-console-template for more information
using Database;

Console.WriteLine("Welcome to RecipeBuild");
Console.Write("Title: ");
string title = Console.ReadLine();

Console.Write("Summary: ");
string summary = Console.ReadLine();

Console.Write("Image: ");
string image = Console.ReadLine();

Console.Write("Minutes: ");
string input = Console.ReadLine();  
int minutes = int.Parse(input);

RecipeClass recipe = new RecipeClass(){
    Title = title, 
    Summary = summary,
    Image = image, 
    Minutes = minutes
    }
    ; ; 
Mongodb db = new Mongodb(); 
await db.SaveRecipe(recipe);

var recipes = await db.GetAllRecipes();

foreach (var recipeClass in recipes)
{
    Console.WriteLine(recipeClass.Title);
}



