using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Role : BaseEntity<Guid>
{
    public string Name { get;set; }
    public string Description { get; set; }

    #region -- Relationship --

    public HashSet<RoleAccount> RoleAccounts { get; set; }

    #endregion -- Relationship --
}