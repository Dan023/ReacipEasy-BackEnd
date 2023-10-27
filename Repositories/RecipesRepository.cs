using Microsoft.Extensions.Options;
using ReacipEasy.DatabaseConfiguration;
using ReacipEasy.Models;
using ReacipEasy.Repositories.Base;

namespace ReacipEasy.Repositories
{
    public class RecipesRepository : GenericRepository<RecipeModel>
    {
        private const string collectionName = "recipes";
        public RecipesRepository(IOptions<DbConfiguration> dbConfig) : base(dbConfig, collectionName)
        {
        }
    }
}
