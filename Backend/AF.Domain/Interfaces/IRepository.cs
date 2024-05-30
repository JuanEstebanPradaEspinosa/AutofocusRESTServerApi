
using AF.Domain.Pagination;

namespace AF.Domain.Interfaces
{
    public interface IRepository<T> {
        Task<T> GetByIdAsync(int id);
        Task<PagedList<T>> GetAllAsync(QueryStringParameters parameters);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
