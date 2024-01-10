using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Cart : BaseEntity<Guid>
{
    public Customer Customer { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}