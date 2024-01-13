namespace Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CategoryResponse Parent { get; set; }
    public string Image { get; set; }
}