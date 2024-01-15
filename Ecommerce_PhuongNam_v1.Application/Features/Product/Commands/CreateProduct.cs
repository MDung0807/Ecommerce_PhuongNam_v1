using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;

public class CreateProduct : FormCreateProduct, IRequest<bool>
{
    
}

public class CreateProductHandle : IRequestHandler<CreateProduct, bool>
{
    private readonly IProductService _service;
    public CreateProductHandle(IProductService service) => _service = service;
    public async Task<bool> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}