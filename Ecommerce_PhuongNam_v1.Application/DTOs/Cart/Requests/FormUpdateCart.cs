namespace Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;

public class FormUpdateCart
{
    public Guid Id { get; set; }
    public Guid VariantId { get; set; }
    public int Quantity { get; set; }
    public Guid CustomerId { get; set; }
}