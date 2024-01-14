using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Queries;

public class GetShop : IRequest<ShopResponse>
{
    public Guid Id { get; set; }
}

public class GetShopHandle : IRequestHandler<GetShop, ShopResponse>
{
    
    private readonly IShopService _service;
    public GetShopHandle(IShopService service) => _service = service;

    public async Task<ShopResponse> Handle(GetShop request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}