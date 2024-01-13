using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;

public class UpdateBrand : FormUpdate, IRequest<bool>
{
    
}

public class UpdateBrandHandle : IRequestHandler<UpdateBrand, bool>
{
    private readonly IBrandService _service;

    public UpdateBrandHandle(IBrandService service) => _service = service;
    public async Task<bool> Handle(UpdateBrand request, CancellationToken cancellationToken)
    {
        return await _service.Update(request);
    }
}