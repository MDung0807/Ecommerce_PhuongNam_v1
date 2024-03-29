﻿using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Variant : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public decimal OriginPrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal FinalPrice { get; set; }
    public long Quantity { get; set; }

    #region --Relationship --
    public Product Product { get; set; }
    public HashSet<Specification> Specifications { get; set; }    
    public HashSet<CartItem> CartItems { get; set; }
    public HashSet<Offer> Offers { get; set; }
    public HashSet<OrderItem> OrderItems { get; set; }
    #endregion --Relationship --
    
}