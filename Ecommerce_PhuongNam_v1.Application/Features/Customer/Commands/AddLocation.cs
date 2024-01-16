using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class AddLocation : LocationRequest, IRequest<bool>
{ 
    
}

public class AddLocationHandle : IRequestHandler<AddLocation, bool>
{
    private readonly ICustomerService _service;
    private readonly ICurrentUserService _currentUserService;

    public AddLocationHandle(ICurrentUserService currentUserService, ICustomerService service)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<bool> Handle(AddLocation request, CancellationToken cancellationToken)
    {
        request.CustomerId = new Guid(_currentUserService.IdUser);
        return await _service.AddLocation(request: request);
    }
}