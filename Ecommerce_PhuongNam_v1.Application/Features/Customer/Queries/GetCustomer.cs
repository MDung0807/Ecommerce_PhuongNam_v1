using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class GetCustomer : IRequest<ProfileResponse>
{
    public Guid Id { get; set; }
}

public class GetCustomerHandle : IRequestHandler<GetCustomer, ProfileResponse>
{
    private ICurrentUserService _currentUserService;
    public GetCustomerHandle(ICurrentUserService currentUserService) => _currentUserService = currentUserService;
    
    public Task<ProfileResponse> Handle(GetCustomer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}