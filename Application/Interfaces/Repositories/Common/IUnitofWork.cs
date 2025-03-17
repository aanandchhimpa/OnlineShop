using Domain.Common;
using Domain.Entities.Brands;
using Domain.Entities.Categories;

namespace Application.Interfaces.Repositories.Common
{
    public interface IUnitofWork: IDisposable
    {
        public IGenericRepository<Brand> Brand { get; }
        public IGenericRepository<Category> Category { get; }
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
