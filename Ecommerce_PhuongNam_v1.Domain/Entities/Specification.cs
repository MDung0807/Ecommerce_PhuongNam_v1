using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Specification : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Value { get; set; }
    public Variant Variant { get; set; }
    
}