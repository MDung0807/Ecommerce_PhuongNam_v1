using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class RemoveLocation : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class RemoveLocationHandle : IRequestHandler<RemoveLocation, bool>
{
    private readonly ICustomerService _service;

    public RemoveLocationHandle(ICustomerService service)
    {
        _service = service;
    }
    public async Task<bool> Handle(RemoveLocation request, CancellationToken cancellationToken)
    {
        return await _service.RemoveAddress(request.Id);
    }
}