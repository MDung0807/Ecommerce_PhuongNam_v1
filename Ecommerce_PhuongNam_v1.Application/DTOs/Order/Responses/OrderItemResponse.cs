using Ecommerce_PhuongNam_v1.Application.Common.Responses;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;

public class OrderItemResponse
{
    public List<OrderItemResponse> ItemResponses { get;set; }
    public decimal TotalAmount { get; set; }

    public Guid FromAddressId { get; set; }
    public LocationResponse FromAddress { get; set; }
    public LocationResponse ToAddress { get; set; }
    public Guid ShippingMethodId { get; set; }
    public string ShippingMethodName { get; set; }
    public Guid PaymentMethodId { get; set; }
    public string PaymentMethodName { get; set; }
}