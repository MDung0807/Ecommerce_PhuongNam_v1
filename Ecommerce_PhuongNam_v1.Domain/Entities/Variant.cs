using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Variant : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public decimal OriginPrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal FinalPrice { get; set; }

    #region --Relationship --
    public Product Product { get; set; }
    public ICollection<Specification> Specifications { get; set; }    
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<Offer> Offers { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    #endregion --Relationship --
    
}