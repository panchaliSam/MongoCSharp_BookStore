using MongoCSharp_BookStore.Data.Repositories;
using MongoCSharp_BookStore.Models;

namespace MongoCSharp_BookStore.Services
{
    public class BookStoreService(IBookStoreRepository repo) : IBookStoreService
    {
        public async Task SeedIfEmptyAsync()
        {
            List<BookStore> all = await repo.GetAllAsync();
            if (all.Count > 0) return;

            var seed = new List<BookStore>
            {
                new() { ISBN = "8767687689898yu", BookTitle = "MongoDB Basics", Author = "Tanya", Category = "NoSQL DBMS", Price = 456 },
                new() { ISBN = "27758987689898yu", BookTitle = "C# Basics", Author = "Tanvi", Category = "Programming Languages", TotalPages = 376, Price = 289 },
                new() { ISBN = "117675787689898yu", BookTitle = "SQL Server Basics", Author = "Tushar", Category = "RDBMS", TotalPages = 250, Price = 478 },
                new() { ISBN = "6779799933389898yu", BookTitle = "Entity Framework Basics", Author = "Somya", Category = "ORM tool", TotalPages = 175, Price = 289 },
            };

            await repo.InsertManyAsync(seed);
            Console.WriteLine("[BookStoreService] Seeded initial data.");
        }

        public Task<List<BookStore>> GetAllAsync() => repo.GetAllAsync();

        public Task<BookStore?> GetCheapestAsync() => repo.GetCheapestAsync();

        public Task<List<BookStore>> GetByMinPagesAsync(int minPages) => repo.GetByMinPagesAsync(minPages);

        public Task<BookStore?> GetByIsbnAsync(string isbn) => repo.GetByIsbnAsync(isbn);

        public Task AddAsync(BookStore book) => repo.InsertAsync(book);

        public async Task<long> WipeAllAsync() =>
            await repo.DeleteManyAsync(_ => true);
    }
}