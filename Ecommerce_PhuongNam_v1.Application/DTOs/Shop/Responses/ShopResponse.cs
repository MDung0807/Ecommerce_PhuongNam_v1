namespace Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Responses;

public class ShopResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsMall { get; set; }
    public string Logo { get; set; }
}