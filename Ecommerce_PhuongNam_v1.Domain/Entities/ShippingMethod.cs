using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class ShippingMethod : BaseEntity<Guid>
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public decimal MaxWidth { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal MaxLenght { get; set; }

    #region -- Relationship --
    public HashSet<Order> Orders { get; set; }
    #endregion -- Relationship --
}