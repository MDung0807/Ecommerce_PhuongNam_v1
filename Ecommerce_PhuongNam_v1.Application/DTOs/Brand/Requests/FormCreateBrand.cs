using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;

public class FormCreateBrand
{
    public string Name { get; set; }
    public string Description { get; set; }
}