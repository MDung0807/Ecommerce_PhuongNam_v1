namespace Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;

public class FormCreateOrder
{
    public List<OrderItemRequest> ItemRequests { get; set; }
    public Guid ToAddressId { get; set; }
    public Guid ShippingMethodId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid CustomerId { get; set; }
}