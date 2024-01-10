using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class CreateCustomer :FormRegister, IRequest<bool>
{
    
}

public class CreateCustomerHandle : IRequestHandler<CreateCustomer, bool>
{
    public Task<bool> Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}