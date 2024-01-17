using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Order.Queries;

public class GetOrder : IRequest<OrderResponse>
{
    public Guid Id { get; set; }
}

public class GetOrderHandle : IRequestHandler<GetOrder, OrderResponse>
{
    private readonly IOrderService _service;

    public GetOrderHandle(IOrderService service)
    {
        _service = service;
    }
    public async Task<OrderResponse> Handle(GetOrder request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}