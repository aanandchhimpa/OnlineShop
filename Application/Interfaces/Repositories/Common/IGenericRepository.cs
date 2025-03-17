using Domain.Common;

namespace Application.Interfaces.Repositories.Common
{
    public interface IGenericRepository<T> where T: BaseAuditableEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetQueryable();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(Guid id);
    }
}
