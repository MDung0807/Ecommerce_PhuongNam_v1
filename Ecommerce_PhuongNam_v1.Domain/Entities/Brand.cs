using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Brand : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public HashSet<Product> Products { get; set; }
}