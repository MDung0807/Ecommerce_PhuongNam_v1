using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class AddressDetail : BaseEntity<Guid>
{
    public string Address { get; set; }
    public bool IsPrimary { get; set; }

    #region -- Relationship --
    public Customer Customer { get; set; }
    public Shop Shop { get; set; }
    public Ward Ward { get; set; }
    public ICollection<Order> Sends { get; set; }
    public ICollection<Order> Recevices { get; set; }

    #endregion -- Relationship --
}