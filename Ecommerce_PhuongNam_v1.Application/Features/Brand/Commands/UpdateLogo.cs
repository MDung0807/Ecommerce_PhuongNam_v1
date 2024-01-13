using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;

public class UpdateLogoBrand : UpdateLogo, IRequest<bool>
{
    
}

public class UpdateLogoHandle : IRequestHandler<UpdateLogoBrand, bool >
{
    private readonly IBrandService _service;

    public UpdateLogoHandle(IBrandService service) => _service = service;
    public async Task<bool> Handle(UpdateLogoBrand request, CancellationToken cancellationToken)
    {
        return await _service.UpdateLogo(request);
    }
}