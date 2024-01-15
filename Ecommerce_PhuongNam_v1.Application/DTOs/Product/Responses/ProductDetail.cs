using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Responses;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;

public class ProductDetail : ProductResponse
{
    public string BrandName { get; set; }
    public Guid BrandId { get; set; }
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }
    public List<VariantResponse> Variants { get; set; }
}