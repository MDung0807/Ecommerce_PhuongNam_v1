using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;

public class FormCreateProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ShopId { get; set; }
    
    public List<FormCreateVariant> Variants { get; set; }
    public List<ProductImageRequest> Images { get; set; }
}