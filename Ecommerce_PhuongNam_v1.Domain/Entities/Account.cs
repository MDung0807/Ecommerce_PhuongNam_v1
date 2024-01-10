using Ecommerce_PhuongNam_v1.Domain.Common;

namespace Ecommerce_PhuongNam_v1.Domain.Entities
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
