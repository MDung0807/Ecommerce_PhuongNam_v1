using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;

public class ChangeIsShopWaiting : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class ChangeIsWaitingHandle : IRequestHandler<ChangeIsShopWaiting, bool>
{
    
    private readonly IShopService _service;
    public ChangeIsWaitingHandle(IShopService service) => _service = service;

    public async Task<bool> Handle(ChangeIsShopWaiting request, CancellationToken cancellationToken)
    {
        return await _service.ChangeToWaiting(request.Id);
    }
}