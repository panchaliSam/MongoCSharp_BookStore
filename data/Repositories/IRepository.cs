using System.Linq.Expressions;

namespace MongoCSharp_BookStore.repository
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);
        Task<bool> DeleteByIdAsync(string id);
        Task<long> DeleteManyAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}