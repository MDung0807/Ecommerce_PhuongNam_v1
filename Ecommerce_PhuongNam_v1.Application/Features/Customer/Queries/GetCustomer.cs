using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class GetCustomer : IRequest<ProfileResponse>
{
    public Guid Id { get; set; }
}

public class GetCustomerHandle : IRequestHandler<GetCustomer, ProfileResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ICustomerService _service;

    public GetCustomerHandle(ICurrentUserService currentUserService, ICustomerService service)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    
    public async Task<ProfileResponse> Handle(GetCustomer request, CancellationToken cancellationToken)
    {
        if (request.Id == default)
            request.Id = new Guid(_currentUserService.IdUser);
        return await _service.GetById(request.Id);
    }
}