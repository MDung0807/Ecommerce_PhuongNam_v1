using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class PaymentMethod : BaseEntity<Guid>
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}