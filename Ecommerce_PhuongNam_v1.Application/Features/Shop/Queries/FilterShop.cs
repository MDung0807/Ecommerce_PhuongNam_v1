using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Queries;

public class FilterShop : FilterShopRequest, IRequest<ShopPagingResult>
{
    

}

public class FilterShopHandle : IRequestHandler<FilterShop, ShopPagingResult>
{
    
    private readonly IShopService _service;
    public FilterShopHandle(IShopService service) => _service = service;

    public async Task<ShopPagingResult> Handle(FilterShop request, CancellationToken cancellationToken)
    {
        return await _service.FilterShop(request);
    }
}