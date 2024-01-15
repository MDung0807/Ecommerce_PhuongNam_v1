namespace Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;

public class FormAddCart
{
    public Guid VariantId { get; set; }
    public int Quantity { get; set; }
    public Guid CustomerId { get; set; }
}