
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Entities;

namespace BusBookTicket.Core.Models.Entity
{
    public class Account: BaseEntity<Guid>
    {
        #region -- Properties --
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion -- Properties --

        #region -- Relationship ---
        public Customer Customer { get; set; }
        public Shop Shop { get; set; }
        public ICollection<RoleAccount> RoleAccounts { get; set; }
        public ICollection<Auth> Auths { get; set; }
        #endregion -- Relationship ---

    }
}
