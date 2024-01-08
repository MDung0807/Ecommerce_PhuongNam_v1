using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Category : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Image { get; set; }
    public long ParentId { get; set; }
    public List<Product> Products { get; set; }

}