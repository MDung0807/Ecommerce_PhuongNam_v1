using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;

public class ChangeIsActiveProduct : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class ChangeIsActiveHandle : IRequestHandler<ChangeIsActiveProduct, bool>
{
    private readonly IProductService _service;
    public ChangeIsActiveHandle(IProductService service) => _service = service;
    public async Task<bool> Handle(ChangeIsActiveProduct request, CancellationToken cancellationToken)
    {
        return await _service.ChangeIsActive(request.Id);
    }
}