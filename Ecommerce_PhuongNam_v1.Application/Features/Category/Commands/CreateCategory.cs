using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Commands;

public class CreateCategory : FormCreateCategory, IRequest<bool>
{
    
}

public class CreateCategoryHandle : IRequestHandler<CreateCategory, bool>
{
    private readonly ICategoryService _service;

    public CreateCategoryHandle(ICategoryService service) => _service = service;
    public async Task<bool> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}