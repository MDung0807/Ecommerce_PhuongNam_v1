using Ecommerce_PhuongNam_v1.Application.Paging.Order;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Order;

public sealed class OrderSpecification : BaseSpecification<Domain.Entities.Order>
{
    public OrderSpecification(Guid id= default, Guid customerId = default, int status = default, OrderPaging paging = null,
        bool checkStatus = true, bool getIsChange = false)
    : base(x => 
        (id == default || x.Id == default) &&
        (customerId == default || x.Customer.Id == customerId) &&
        (status == default || x.Status == status))
    {
        if (getIsChange)
        {
            return;
        }

        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
        
        AddInclude(x => x.Customer);
        AddInclude(x => x.FromAddress);
        AddInclude(x => x.ToAddress);
        AddInclude(x => x.OrderItems);
        AddInclude(x => x.ShippingMethod);
        AddInclude(x => x.PaymentMethod);
    }
}