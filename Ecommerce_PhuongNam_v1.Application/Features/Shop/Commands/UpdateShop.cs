using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;

public class UpdateShop : FormUpdateShop, IRequest<bool>
{
    
}

public class UpdateShopHandle : IRequestHandler<UpdateShop, bool>
{
    private readonly IShopService _service;
    public UpdateShopHandle(IShopService service) => _service = service;
    
    public async Task<bool> Handle(UpdateShop request, CancellationToken cancellationToken)
    {
        return await _service.Update(request);
    }
}