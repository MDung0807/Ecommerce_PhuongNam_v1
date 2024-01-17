using System.Data.SqlTypes;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public decimal TotalAmount { get; set; }

    #region -- Relationship --
    public AddressDetail FromAddress { get; set; }
    public AddressDetail ToAddress { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public HashSet<OrderItem> OrderItems { get; set; }
    public Customer Customer;

    #endregion -- Relationship --
}