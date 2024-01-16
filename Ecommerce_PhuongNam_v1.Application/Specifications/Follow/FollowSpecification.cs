using Ecommerce_PhuongNam_v1.Application.Paging.Follow;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Follow;

public sealed class FollowSpecification : BaseSpecification<UserFollowShop>
{
    public FollowSpecification(Guid id = default, Guid customerId = default, Guid shopId = default, FollowPaging paging = null)
    :base(x => 
        (id == default || x.Id == id) &&
        (customerId == default || x.Customer.Id == customerId) &&
        (shopId == default || x.Shop.Id == shopId))
    {
        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }

}