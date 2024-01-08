using System.Linq.Expressions;
using Ecommerce_PhuongNam_v1.Application.Specifications.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

/// <summary>
/// Generic Repository
/// </summary>
/// <typeparam name="T">T is Entity</typeparam>
/// <typeparam name="TId"></typeparam>
public interface IGenericRepository<T, TId>: IRepository<T, TId> where T : BaseEntity<TId>
{
    /// <summary>
    /// Get data from database use specification
    /// </summary>
    /// <param name="specification">specification</param>
    /// <param name="checkStatus">check status is data. If status false then response mess and error</param>
    /// <returns></returns>
    Task<T> Get(ISpecification<T> specification, bool checkStatus = true);
    
    /// <summary>
    /// Get list data from database use specification
    /// </summary>
    /// <param name="specification">specification</param>
    /// <returns></returns>
    Task<List<T>> ToList(ISpecification<T> specification);
    
    /// <summary>
    /// Check Contains data in database
    /// </summary>
    /// <param name="specification">specification</param>
    /// <returns value="bool">true or false. True is contains</returns>
    Task<bool> Contains(ISpecification<T> specification = null);
    
    /// <summary>
    /// Check Contains data in database
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <example>x => x.type == "auto"</example>
    /// <returns value="bool">true or false. True is contains</returns>

    Task<bool> Contains(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Count item in database
    /// </summary>
    /// <param name="specification">specification</param>
    /// <returns value="int"></returns>
    Task<int> Count(ISpecification<T> specification = null);
    
    /// <summary>
    /// Count item in database
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <returns value="int"></returns>
    Task<int> Count(Expression<Func<T, bool>> predicate);
}