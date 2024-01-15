using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;

public class ProductImageRequest
{
    public IFormFile Image { get; set; }
    public bool IsPrimary { get; set; }
}