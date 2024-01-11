using Ecommerce_PhuongNam.Common.Entities.Interfaces;

namespace Ecommerce_PhuongNam_v1.Domain.Common;


public class BaseEntity<T> : IEntity<T>
{
    public T Id {get; set;}
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
    public int Status { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}