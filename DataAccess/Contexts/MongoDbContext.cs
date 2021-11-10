using Core.DataAccess.DbSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.Connection_String);
            _database = client.GetDatabase(settings.Value.Database_Name);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>() => _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        public IMongoDatabase GetDatabase() => _database;
    }
}
