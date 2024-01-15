using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;

public class ChangeIsDisableProduct : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class ChangeIsDisableHandle : IRequestHandler<ChangeIsDisableProduct, bool>
{
    private readonly IProductService _service;
    public ChangeIsDisableHandle(IProductService service) => _service = service;
    public async Task<bool> Handle(ChangeIsDisableProduct request, CancellationToken cancellationToken)
    {
        return await _service.ChangeToDisable(request.Id);
    }
}