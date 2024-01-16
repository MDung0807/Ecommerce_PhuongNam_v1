using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class GetLocation : IRequest<List<CusLocationResponse>>
{
    
}

public class GetLocationHandle : IRequestHandler<GetLocation, List<CusLocationResponse>>
{
    private readonly ICustomerService _service;
    private readonly ICurrentUserService _currentUserService;

    public GetLocationHandle(ICustomerService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<List<CusLocationResponse>> Handle(GetLocation request, CancellationToken cancellationToken)
    {
        return await _service.GetAllLocation(new Guid(_currentUserService.IdUser));
    }
}