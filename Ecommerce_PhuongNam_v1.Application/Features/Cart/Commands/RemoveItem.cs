using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Cart.Commands;

public class RemoveItem : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class RemoveItemHandle : IRequestHandler<RemoveItem, bool>
{
    private readonly ICartService _service;

    public RemoveItemHandle(ICartService service)
    {
        _service = service;
    }
    public async Task<bool> Handle(RemoveItem request, CancellationToken cancellationToken)
    {
        return await _service.RemoveItem(request.Id);
    }
}