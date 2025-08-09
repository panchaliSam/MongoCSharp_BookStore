using MongoCSharp_BookStore.model;

namespace MongoCSharp_BookStore.service
{
    public interface IBookStoreService
    {
        Task SeedIfEmptyAsync();
        Task<List<BookStore>> GetAllAsync();
        Task<BookStore?> GetCheapestAsync();
        Task<List<BookStore>> GetByMinPagesAsync(int minPages);
        Task<BookStore?> GetByIsbnAsync(string isbn);
        Task AddAsync(BookStore book);
        Task<long> WipeAllAsync();
    }
}