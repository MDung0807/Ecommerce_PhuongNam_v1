using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Queries;

public class GetListCategory : CategoryPaging, IRequest<CategoryPagingResult>
{
    
}

public class GetListHandle : IRequestHandler<GetListCategory, CategoryPagingResult>
{
    private readonly ICategoryService _service;

    public GetListHandle(ICategoryService service) => _service = service;
    public async Task<CategoryPagingResult> Handle(GetListCategory request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request);
    }
}