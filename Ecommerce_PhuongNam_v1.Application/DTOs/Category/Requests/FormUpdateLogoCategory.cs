using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;

public class FormUpdateLogoCategory
{
    public Guid Id { get; set; }
    public IFormFile Image { get; set; }
}