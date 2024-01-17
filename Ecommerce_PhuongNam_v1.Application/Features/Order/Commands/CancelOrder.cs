using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Order.Commands;

public class CancelOrder : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class CancelOrderHandle : IRequestHandler<CancelOrder, bool>
{
    private IOrderService _service;

    public CancelOrderHandle(IOrderService service)
    {
        _service = service;
    }
    
    public async Task<bool> Handle(CancelOrder request, CancellationToken cancellationToken)
    {
        return await _service.Delete(request.Id);
    }
}