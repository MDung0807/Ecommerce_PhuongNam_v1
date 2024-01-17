using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Order;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Order.Queries;

public class GetListOrder : OrderPaging, IRequest<OrderPagingResult>
{
    
}

public class GetListOrderHandle : IRequestHandler<GetListOrder, OrderPagingResult>
{
    private readonly IOrderService _service;
    private readonly ICurrentUserService _currentUserService;

    public GetListOrderHandle(IOrderService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<OrderPagingResult> Handle(GetListOrder request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request, new Guid(_currentUserService.IdUser));
    }
}