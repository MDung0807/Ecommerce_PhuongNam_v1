namespace Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;

public class FormCreateCategory
{
    public string Name { get; set; }
    public Guid ParentId { get; set; }
}