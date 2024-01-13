namespace Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;

public class FormUpdateCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ParentId { get; set; }
}