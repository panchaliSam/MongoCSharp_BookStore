using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoCSharp_BookStore.config;

namespace MongoCSharp_BookStore.data.Impl
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;
        public MongoContext()
        {
            var client = new MongoClient(DbConfig.ConnectionString);
            _database = client.GetDatabase(DbConfig.DatabaseName);
        }
        public IMongoDatabase Database => _database;

        public void EnsureCollectionExists(string name)
        {
            var filter = new BsonDocument("name", name);
            var options = new ListCollectionsOptions { Filter = filter };
            var exists = _database.ListCollections(options).Any();

            if (!exists)
            {
                _database.CreateCollection(name);
                Console.WriteLine($"[MongoContext] Created collection '{name}'.");
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _database.GetCollection<T>(name);
    }
}