
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam.Common.Repositories.Interfaces;

/// <summary>
/// Is Communication with Database
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Save change all activity
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
    
    /// <summary>
    /// Begin transaction in activity
    /// </summary>
    /// <returns></returns>
    Task BeginTransaction();
    
    /// <summary>
    /// Rollback activity when has error
    /// </summary>
    /// <returns></returns>
    Task RollbackTransactionAsync();

    /// <summary>
    /// GenericRepository
    /// </summary>
    /// <typeparam name="T">Is Entity, T: BaseEntity</typeparam>
    /// <typeparam name="TId"></typeparam>
    /// <returns></returns>
    IGenericRepository<T, TId> GenericRepository<T, TId>() where T : BaseEntity<TId>;
    
    /// <summary>
    /// Complete activity
    /// </summary>
    /// <returns></returns>
    Task<int> Complete();
}