using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Mongodb
    {
        private IMongoDatabase GetDb()
        {
            MongoClient _client = new MongoClient();
            var db = _client.GetDatabase("MyRecipeDB");
                return db;
        }

        public async Task SaveRecipe(RecipeClass recipe)
        {
           await  GetDb().GetCollection<RecipeClass>("Recipes")
            .InsertOneAsync(recipe);
        }

        public async Task<List<RecipeClass>> GetAllRecipes()
        {
          var recipes =  await GetDb().GetCollection<RecipeClass>("Recipes")
                .Find(r => true).ToListAsync();
            return recipes; 
        }

        public async Task<RecipeClass> GetRecipeById(string id)
        {
            ObjectId _Id = new ObjectId(id);
            var recipe = await GetDb().GetCollection<RecipeClass>("Recipes")
                .Find(r => r.Id == _Id)
                .SingleOrDefaultAsync();    

            return recipe;  
        }

        public async Task DeleteRecipe(string id)
        {
            ObjectId _id = new ObjectId(id);
            await GetDb().GetCollection<RecipeClass>("Recipes")
                .DeleteOneAsync(r => r.Id == _id);
        }
    }
}
