using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class ProductImage : BaseEntity<Guid>
{
    public string Image { get; set; }
    public bool IsPrimary { get; set; }
    public Product Product;
}