using Microsoft.Extensions.Options;
using ReacipEasy.DatabaseConfiguration;
using ReacipEasy.Models;
using ReacipEasy.Repositories.Base;

namespace ReacipEasy.Repositories
{
    public class UsersRepository : GenericRepository<UserModel>
    {
        private const string collectionName = "users";
        public UsersRepository(IOptions<DbConfiguration> dbConfig) : base(dbConfig, collectionName)
        {
        }
    }
}
