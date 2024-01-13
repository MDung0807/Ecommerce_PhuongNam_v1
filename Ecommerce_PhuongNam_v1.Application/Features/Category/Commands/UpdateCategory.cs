using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Commands;

public class UpdateCategory : FormUpdateCategory, IRequest<bool>
{
    
}

public class UpdateCategoryHandle : IRequestHandler<UpdateCategory, bool>
{
    private readonly ICategoryService _service;

    public UpdateCategoryHandle(ICategoryService service) => _service = service;
    public async Task<bool> Handle(UpdateCategory request, CancellationToken cancellationToken)
    {
        return await _service.Update(request);
    }
}