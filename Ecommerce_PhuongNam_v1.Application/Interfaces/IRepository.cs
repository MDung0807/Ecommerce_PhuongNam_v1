using Ecommerce_PhuongNam_v1.Application.Specifications.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Common;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces
{
    /// <summary>
    /// Communication with database
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<T, TId> where T: BaseEntity<TId>
    {
        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID in entity update</returns>
        Task<T> Update(T entity);

        /// <summary>
        /// Update status entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<T> Delete(T entity);
        
        /// <summary>
        /// Insert entity TIdo database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="userId">ID user</param>
        /// <returns>ID for entity in database</returns>
        Task<T> Create(T entity);

        Task<bool> CreateRange(List<T> entities);

        /// <summary>
        /// Change status in entity and reference entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <param name="listObjectNotChange">List object not change status</param>
        /// <returns></returns>
        Task<bool> ChangeStatus(object entity, int status, List<Dictionary<string, TId>> listObjectNotChange = null);

        /// <summary>
        /// Check data is exist in database
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        Task<bool> CheckIsExist(ISpecification<T> specification);

        /// <summary>
        /// Create or Update entity. Create if not exist
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        Task<T> CreateOrUpdate(T entity);

        /// <summary>
        /// Permanently deleted in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteHard(T entity);
    }
}
