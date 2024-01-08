namespace Ecommerce_PhuongNam.Common.Entities.Interfaces;

public interface IAuditableEntity<T>
{
    T CreateBy { get; set; }
    T UpdateBy { get; set; }
}