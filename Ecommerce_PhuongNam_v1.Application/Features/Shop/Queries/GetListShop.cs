using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Queries;

public class GetListShop :ShopPaging,  IRequest<ShopPagingResult>
{
    
}

public class GetListShopHandle : IRequestHandler<GetListShop, ShopPagingResult>
{
    
    private readonly IShopService _service;
    public GetListShopHandle(IShopService service) => _service = service;

    public async Task<ShopPagingResult> Handle(GetListShop request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request);
    }
}