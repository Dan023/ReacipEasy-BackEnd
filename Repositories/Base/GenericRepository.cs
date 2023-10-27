using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ReacipEasy.DatabaseConfiguration;

namespace ReacipEasy.Repositories.Base
{
    public class GenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IOptions<DbConfiguration> _dbConfig;
        public GenericRepository(IOptions<DbConfiguration> dbConfig, string collectionName)
        {
            _dbConfig = dbConfig;
            var mongoClient = new MongoClient(_dbConfig.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbConfig.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(id);
        }

        public async Task Update(T entity, string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task<List<T>> GetAll()
        {
            var q = await _collection.Find(_ => true).ToListAsync();
            return q;
        }

        public async Task<T> GetById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
