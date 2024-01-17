using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Order;

public class OrderItemSpecification : BaseSpecification<OrderItem>
{
    public OrderItemSpecification(Guid orderId)
        : base(x => x.Order.Id == orderId)

    {

    }
}