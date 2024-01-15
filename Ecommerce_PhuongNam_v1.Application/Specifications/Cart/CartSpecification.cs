namespace Ecommerce_PhuongNam_v1.Application.Specifications.Cart;

public class CartSpecification : BaseSpecification<Domain.Entities.Cart>
{
    public CartSpecification(Guid id = default, Guid userId = default)
    : base(x => x.Customer.Cart.Id == userId)
    {
        
    }
}