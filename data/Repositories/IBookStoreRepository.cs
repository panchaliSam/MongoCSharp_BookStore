using MongoCSharp_BookStore.Models;

namespace MongoCSharp_BookStore.Data.Repositories
{
    public interface IBookStoreRepository : IRepository<BookStore>
    {
        Task<BookStore?> GetByIsbnAsync(string isbn);
        Task<BookStore?> GetCheapestAsync();
        Task<List<BookStore>> GetByMinPagesAsync(int minPages);
    }
}