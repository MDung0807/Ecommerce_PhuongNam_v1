namespace Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Responses;

public class CartIItemResponse
{
    public string ProductName { get; set; }
    public Guid ProductId { get; set; }
    public string Image { get; set; }
    public string VariantName { get; set; }
    public int QuantityId { get; set; }
    public Guid VariantId { get; set; }
}