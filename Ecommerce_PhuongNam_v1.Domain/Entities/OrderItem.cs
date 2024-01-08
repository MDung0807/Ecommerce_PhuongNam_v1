using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class OrderItem : BaseEntity<Guid>
{
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int TotalAmount { get; set; }
    public Variant Variant { get; set; }
    public Order Order { get; set; }
    
}