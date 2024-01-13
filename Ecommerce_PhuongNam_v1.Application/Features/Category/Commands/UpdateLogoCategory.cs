using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Category.Commands;

public class UpdateLogoCategory : FormUpdateLogoCategory, IRequest<bool>
{
    
}

public class UpdateLogoHandle :  IRequestHandler<UpdateLogoCategory, bool>
{
    private readonly ICategoryService _service;

    public UpdateLogoHandle(ICategoryService service) => _service = service;
    public async Task<bool> Handle(UpdateLogoCategory request, CancellationToken cancellationToken)
    {
        return await _service.UpdateLogo(request);
    }
} 