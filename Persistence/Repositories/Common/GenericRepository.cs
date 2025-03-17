using Application.Interfaces.Repositories.Common;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public IQueryable<T> GetQueryable() => _dbSet.AsQueryable();

        public async Task AddAsync(T entity) 
        { 
            entity.CreatedDate = DateTime.UtcNow;             
            await _dbSet.AddAsync(entity); 
        }

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<bool> ExistsAsync(Guid id) => await _dbSet.AnyAsync(e => e.Id == id);
    }
}
