using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;

public class DeleteProduct : IRequest<bool>
{
    public Guid Id { get; set; }    
}

public class DeleteProductHandle : IRequestHandler<DeleteProduct, bool>
{
    private readonly IProductService _service;
    public DeleteProductHandle(IProductService service) => _service = service;
    public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        return await _service.Delete(request.Id);
    }
}
