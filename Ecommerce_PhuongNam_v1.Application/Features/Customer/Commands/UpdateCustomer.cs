using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class UpdateCustomer : FormUpdate, IRequest<bool>
{
    
}

public class UpdateCustomerHandle : IRequestHandler<UpdateCustomer, bool>
{
    public Task<bool> Handle(UpdateCustomer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}