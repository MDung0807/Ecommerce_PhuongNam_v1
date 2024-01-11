namespace Ecommerce_PhuongNam.Common.Entities.Interfaces;

public interface IAuditableEntity
{
    string CreateBy { get; set; }
    string UpdateBy { get; set; }
}