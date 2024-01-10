using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Offer : BaseEntity<Guid>
{
    public decimal OfferAmount { get; set; }
    public Customer Customer { get; set; }
    public Variant Variant { get; set; }
}