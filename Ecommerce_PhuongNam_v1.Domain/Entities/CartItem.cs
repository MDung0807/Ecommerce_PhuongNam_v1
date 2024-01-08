using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class CartItem : BaseEntity<Guid>
{
    public Variant Variant { get; set; }
    public Cart Cart { get; set; }
    public int Quantity { get; set; }
}