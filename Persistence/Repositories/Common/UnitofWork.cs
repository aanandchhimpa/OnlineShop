using Application.Interfaces.Repositories.Common;
using Domain.Common;
using Domain.Entities.Brands;
using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using System.Collections;

namespace Persistence.Repositories.Common
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;
        private Hashtable? _repositories;
        private bool _disposed;


        public IGenericRepository<Brand> Brand { get; }
        public IGenericRepository<Category> Category { get; }
        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository<T>)_repositories[type]!;
        }

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction?.Dispose();
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}

