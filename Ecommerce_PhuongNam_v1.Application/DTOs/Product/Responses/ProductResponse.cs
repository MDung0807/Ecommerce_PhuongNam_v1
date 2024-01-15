namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public double Rating { get; set; }
    public string Shop { get; set; }
    public Guid ShopId { get; set; }
    public List<ProductImageResponse> Images { get; set; }
}

public class ProductImageResponse
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public bool IsPrimary { get; set; }
}