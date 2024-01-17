using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Order.Commands;

public class CreateOrder : FormCreateOrder, IRequest<bool>
{
    
}

public class CreateOrderHandle : IRequestHandler<CreateOrder, bool>
{
    private readonly IOrderService _service;
    private readonly ICurrentUserService _currentUserService;

    public CreateOrderHandle(IOrderService service, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _service = service;
    }
    public async Task<bool> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        request.CustomerId = new Guid(_currentUserService.IdUser);
        return await _service.Create(request);
    }
}