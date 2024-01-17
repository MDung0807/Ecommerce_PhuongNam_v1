namespace Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;

public class OrderItemRequest
{
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int TotalAmount { get; set; }
    public Guid VariantId { get; set; }
}