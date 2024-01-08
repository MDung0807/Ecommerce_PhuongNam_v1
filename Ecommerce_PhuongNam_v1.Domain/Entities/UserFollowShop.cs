using BusBookTicket.Core.Models.Entity;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class UserFollowShop : BaseEntity<Guid>
{
    public Customer Customer { get; set; }
    public Shop Shop { get; set; }
}