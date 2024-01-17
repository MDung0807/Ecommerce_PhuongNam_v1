using Ecommerce_PhuongNam_v1.Application.Common.Responses;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;

public class OrderItemResponse
{
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int TotalAmount { get; set; }
    public Guid VariantId { get; set; }
    public string VariantName { get; set; }
}