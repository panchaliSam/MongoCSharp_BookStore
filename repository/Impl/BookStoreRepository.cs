using System.Linq.Expressions;
using MongoDB.Driver;
using MongoCSharp_BookStore.config;
using MongoCSharp_BookStore.data;
using MongoCSharp_BookStore.model;
using MongoCSharp_BookStore.repository;

namespace MongoCSharp_BookStore.repository.Impl
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly IMongoCollection<BookStore> _collection;

        public BookStoreRepository(IMongoContext context)
        {
            context.EnsureCollectionExists(DbConfig.CollectionName);
            _collection = context.GetCollection<BookStore>(DbConfig.CollectionName);
        }

        //Generic methods
        public async Task<BookStore?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<BookStore>> GetAllAsync() =>
            await _collection.Find(Builders<BookStore>.Filter.Empty).ToListAsync();

        public async Task<List<BookStore>> FindAsync(Expression<Func<BookStore, bool>> predicate) =>
            await _collection.Find(predicate).ToListAsync();

        public async Task InsertAsync(BookStore entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task InsertManyAsync(IEnumerable<BookStore> entities) =>
            await _collection.InsertManyAsync(entities);

        public async Task<bool> DeleteByIdAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<long> DeleteManyAsync(Expression<Func<BookStore, bool>> predicate)
        {
            var result = await _collection.DeleteManyAsync(predicate);
            return result.DeletedCount;
        }

        public async Task<BookStore?> FirstOrDefaultAsync(Expression<Func<BookStore, bool>> predicate) =>
            await _collection.Find(predicate).FirstOrDefaultAsync();

        //Specific methods
        public async Task<BookStore?> GetByIsbnAsync(string isbn) =>
            await _collection.Find(b => b.ISBN == isbn).SingleOrDefaultAsync();

        public async Task<BookStore?> GetCheapestAsync() =>
            await _collection.Find(Builders<BookStore>.Filter.Empty)
                             .SortBy(b => b.Price)
                             .FirstOrDefaultAsync();

        public async Task<List<BookStore>> GetByMinPagesAsync(int minPages) =>
            await _collection.Find(b => b.TotalPages != null && b.TotalPages > minPages).ToListAsync();
    }
}