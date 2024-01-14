using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;

public class CreateShop : FormCreateShop, IRequest<bool>
{
    
}

public class CreateShopHandle : IRequestHandler<CreateShop, bool>
{
    private readonly IShopService _service;
    public CreateShopHandle(IShopService service) => _service = service;
    public async Task<bool> Handle(CreateShop request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}