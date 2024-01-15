using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;

public class UpdateProduct : FormUpdateProduct, IRequest<bool>
{
    
}

public class UpdateProductHandle : IRequestHandler<UpdateProduct, bool>
{
    private readonly IProductService _service;
    public UpdateProductHandle(IProductService service) => _service = service;
    public async Task<bool> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        return await _service.Update(request);
    }
}