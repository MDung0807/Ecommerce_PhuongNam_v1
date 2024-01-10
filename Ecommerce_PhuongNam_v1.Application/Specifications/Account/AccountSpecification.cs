using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Account;

public sealed class AccountSpecification : BaseSpecification<Domain.Entities.Account>
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="username">Username in account</param>
    /// <param name="roleName">Role name</param>
    /// <param name="checkStatus"></param>
    public AccountSpecification(string username, string roleName, bool checkStatus = true) : base(x => x.Username == username, checkStatus)
    {
        if (roleName == AppConstants.SHOP)
            AddInclude(x => x.Shop);
        else
        {
            AddInclude(x => x.Customer);
        }
        AddInclude(x => x.RoleAccounts);
        AddInclude("RoleAccounts.Role");
    }

    public AccountSpecification(string username, bool checkStatus = true)
        : base(x => x.Username == username, checkStatus)
    {
        AddInclude(x => x.Shop);
        AddInclude(x => x.Customer);
        AddInclude(x => x.RoleAccounts);
        AddInclude("RoleAccounts.Role");
        AddInclude(x => x.Auths);
    }

    public AccountSpecification(Guid id, bool checkStatus, bool isDelete = false)
        : base(x => x.Id.Equals( id) 
                    && ((isDelete && x.Status == (int)EnumsApp.Waiting) || true),
            checkStatus: checkStatus)
    {
        
    }
}