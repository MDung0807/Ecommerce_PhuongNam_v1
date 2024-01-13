using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Queries;

public class FilterCategory : FilterCategoryRequest, IRequest<CategoryPagingResult>
{
    
}

public class FilterHandle : IRequestHandler<FilterCategory, CategoryPagingResult>
{
    private readonly ICategoryService _service;

    public FilterHandle(ICategoryService service) => _service = service;
    public async Task<CategoryPagingResult> Handle(FilterCategory request, CancellationToken cancellationToken)
    {
        return await _service.GetFilterCategory(request);
    }
}