using MongoCSharp_BookStore.model;

namespace MongoCSharp_BookStore.repository
{
    public interface IBookStoreRepository : IRepository<BookStore>
    {
        Task<BookStore?> GetByIsbnAsync(string isbn);
        Task<BookStore?> GetCheapestAsync();
        Task<List<BookStore>> GetByMinPagesAsync(int minPages);
    }
}