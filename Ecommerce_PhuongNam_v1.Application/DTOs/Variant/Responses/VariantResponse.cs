using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Responses;

public class VariantResponse
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public decimal OriginPrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal FinalPrice { get; set; }
    public List<FormSpecification> Specifications { get; set; }
}