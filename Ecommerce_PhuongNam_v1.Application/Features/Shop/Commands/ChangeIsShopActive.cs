using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;

public class ChangeIsShopActive : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class ChangeIsActiveHandle: IRequestHandler<ChangeIsShopActive, bool>
{
    
    private readonly IShopService _service;
    public ChangeIsActiveHandle(IShopService service) => _service = service;

    public async Task<bool> Handle(ChangeIsShopActive request, CancellationToken cancellationToken)
    {
        return await _service.ChangeIsActive(request.Id);
    }
}