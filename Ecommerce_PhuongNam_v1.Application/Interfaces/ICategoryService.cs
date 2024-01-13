using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface ICategoryService : IService<FormCreateCategory, FormUpdateCategory, Guid, CategoryResponse, CategoryPaging, CategoryPagingResult>
{
    Task<bool> UpdateLogo(FormUpdateLogoCategory request);
    Task<CategoryPagingResult> GetFilterCategory(FilterCategoryRequest request);
}