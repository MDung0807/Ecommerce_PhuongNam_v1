using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public double Rating { get; set; }

    #region -- Relationship --
    public Brand Brand { get; set; }
    public Category Category { get; set; }
    public HashSet<Review> Reviews { get; set; }
    public HashSet<ProductImage> ProductImages { get; set; }    
    public HashSet<Variant> Variants { get; set; }
    public Shop Shop { get; set; }
    public AddressDetail AddressDetail { get; set; }
    #endregion -- Relationship --
}