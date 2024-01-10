using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class DeleteCustomer : IRequest<bool>
{
    
}

public class DeleteCustomerHandle : IRequestHandler<DeleteCustomer, bool>
{
    public Task<bool> Handle(DeleteCustomer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}