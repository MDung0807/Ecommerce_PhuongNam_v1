using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Cart;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Cart.Queries;

public class GetCart : CartPaging, IRequest<CartPagingResult>
{
    
}

public class GetCartHandle : IRequestHandler<GetCart, CartPagingResult>
{
    private readonly ICartService _service;
    private readonly ICurrentUserService _currentUserService;
    public GetCartHandle(ICartService service, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _service = service;
    }
    public async Task<CartPagingResult> Handle(GetCart request, CancellationToken cancellationToken)
    {
        return await _service.GetCart(request, new Guid(_currentUserService.IdUser));
    }
}