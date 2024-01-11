namespace Ecommerce_PhuongNam.Common.Entities.Interfaces;

/// <summary>
/// This is interface entity, all entities in system must by implement IEntity
/// </summary>
/// <typeparam name="T">Is Data type Id for entity</typeparam>
public interface IEntity<T> : IAuditableEntity
{
    T Id { get; set; }
    DateTime DateCreate { get; set; }
    DateTime DateUpdate { get; set; }
    int Status { get; set; }
}