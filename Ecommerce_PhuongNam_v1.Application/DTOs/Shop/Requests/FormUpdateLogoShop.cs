using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;

public class FormUpdateLogoShop
{
    public Guid Id { get; set; }
    public IFormFile Logo { get; set; }
}