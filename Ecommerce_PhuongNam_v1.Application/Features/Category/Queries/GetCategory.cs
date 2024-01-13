using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Queries;

public class GetCategory : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }
    public GetCategory(Guid id) => Id = id;
}

public class GetCategoryHandle : IRequestHandler<GetCategory, CategoryResponse>
{
    private readonly ICategoryService _service;

    public GetCategoryHandle(ICategoryService service) => _service = service;
    public async Task<CategoryResponse> Handle(GetCategory request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}