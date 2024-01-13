using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;

public class FormUpdateLogoBrand
{
    public Guid Id { get; set; }
    public IFormFile Image { get; set; }
}