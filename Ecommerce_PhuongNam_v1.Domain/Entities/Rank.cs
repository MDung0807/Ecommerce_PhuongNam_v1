using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Rank : BaseEntity<Guid>
{
    public string Name { get; set; }
    public int Level { get; set; }
    public HashSet<Customer> Customers { get; set; }
}