using System.Collections;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;
    private Hashtable _repositories;
    

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveChangesAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task BeginTransaction()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        await DisposeAsync();
    }

    public IGenericRepository<T, TId> GenericRepository<T, TId>() where T : BaseEntity<TId>
    {
        if (_repositories == null)
            _repositories = new Hashtable();
 
        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<,>);
            var constructedType = repositoryType.MakeGenericType(typeof(T), typeof(TId));

            var repositoryInstance = Activator.CreateInstance(constructedType, _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T, TId>)_repositories[type];
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        _transaction.Dispose();
    }
}


