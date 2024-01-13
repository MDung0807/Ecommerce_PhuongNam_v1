using Ecommerce_PhuongNam_v1.Application.Paging.Category;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;

public class FilterCategoryRequest : CategoryPaging
{
    public string Name { get; set; }
    public Guid Parent { get; set; }
}