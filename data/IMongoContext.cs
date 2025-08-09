using MongoDB.Driver;

namespace MongoCSharp_BookStore.data
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
        IMongoCollection<T> GetCollection<T>(string name);
        void EnsureCollectionExists(string name);
    }
}