using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;

public class ChangeIsShopDelete : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class ChangeIsDeleteHandle : IRequestHandler<ChangeIsShopDelete, bool>
{
    
    private readonly IShopService _service;
    public ChangeIsDeleteHandle(IShopService service) => _service = service;
    
    public async Task<bool> Handle(ChangeIsShopDelete request, CancellationToken cancellationToken)
    {
        return await _service.Delete(request.Id);
    }
}