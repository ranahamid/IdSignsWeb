using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(int page, int pageSize);
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec, int page, int pageSize);
        Task<List<T>> ListDescAsync(ISpecification<T> spec, int page, int pageSize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
