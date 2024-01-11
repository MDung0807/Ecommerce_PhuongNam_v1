using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class CreateCustomer :FormRegister, IRequest<bool>
{
    
}

public class CreateCustomerHandle : IRequestHandler<CreateCustomer, bool>
{
    private ICustomerService _service;

    public CreateCustomerHandle(ICustomerService service) => _service = service;
    public async Task<bool> Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}