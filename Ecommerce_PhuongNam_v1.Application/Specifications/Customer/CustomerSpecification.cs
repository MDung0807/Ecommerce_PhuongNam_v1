﻿using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Customer;

public sealed class CustomerSpecification : BaseSpecification<Domain.Entities.Customer>
{
    public CustomerSpecification(CustomerPaging paging = null, bool checkStatus = true, string fullname = default) 
        : base(x => x.Account.RoleAccounts.All(r => r.Role.Name == AppConstants.CUSTOMER) && 
            (fullname == default || x.FullName.Contains(fullname)), checkStatus)
    {
        AddInclude(x => x.Account);
        AddInclude(x => x.Account.RoleAccounts);
        AddInclude("Account.RoleAccounts.Role");
        AddInclude(x => x.Rank);

        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }

    public CustomerSpecification(Guid id, bool checkStatus = true, bool getAll = true) : base(x => x.Id.Equals(id), checkStatus: checkStatus)
    {
        if (!getAll)
        {
            AddInclude(x => x.Account);
            AddInclude(x => x.Account.RoleAccounts);
            return;
        }
        AddInclude(x => x.Account);
        AddInclude(x => x.Account.RoleAccounts);
        AddInclude("Account.RoleAccounts.Role");
        AddInclude(x => x.Rank);
        AddInclude(x => x.AddressDetails);
        AddInclude("AddressDetails.Ward");
    }
    
    public CustomerSpecification(string email, bool checkStatus = true, bool isDelete = false) 
        : base(x => x.Email == email 
                    || (checkStatus == false && isDelete == true && x.Status == (int)EnumsApp.Waiting), checkStatus)
    {
        if (isDelete)
        {
            AddInclude(x => x.Account);
            AddInclude(x => x.Account.RoleAccounts);
            AddInclude(x => x.Account.Auths);
            return;
        }
        AddInclude(x => x.Account);
        AddInclude(x => x.Account.RoleAccounts);
        // AddInclude("RoleAccounts.Role");
        AddInclude(x => x.Rank);
    }
    
}