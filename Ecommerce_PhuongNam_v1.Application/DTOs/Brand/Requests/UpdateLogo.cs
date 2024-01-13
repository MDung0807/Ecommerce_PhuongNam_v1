using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;

public class UpdateLogo
{
    public Guid Id { get; set; }
    public IFormFile Image { get; set; }
}