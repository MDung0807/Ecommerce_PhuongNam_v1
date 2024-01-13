using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;

public class CreateBrand : FormCreateBrand, IRequest<bool>
{
    
}

public class CreateBrandHandle : IRequestHandler<CreateBrand, bool>
{
    private readonly IBrandService _service;

    public CreateBrandHandle(IBrandService service) => _service = service;
    public async Task<bool> Handle(CreateBrand request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}