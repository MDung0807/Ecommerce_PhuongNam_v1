using BusBookTicket.Core.Models.Entity;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class RoleAccount : BaseEntity<Guid>
{
    public Role Role { get; set; }
    public Account Account { get; set; }
}