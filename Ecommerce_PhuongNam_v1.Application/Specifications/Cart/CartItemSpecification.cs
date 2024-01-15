using Ecommerce_PhuongNam_v1.Application.Paging.Cart;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Cart;

public class CartItemSpecification : BaseSpecification<CartItem>
{
    public CartItemSpecification(Guid id = default, Guid customerId = default, Guid variantId = default, CartPaging paging = null)
    :base(x => 
        (id == default || x.Id == id) &&
        (customerId == default || x.Cart.Customer.Id == customerId) &&
        (variantId == default || x.Variant.Id == variantId))
    {
        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}