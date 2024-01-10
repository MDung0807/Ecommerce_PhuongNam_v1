using Ecommerce_PhuongNam_v1.Application.Paging.Customer;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class GetListCustomer : IRequest<CustomerPagingResult>
{
    
}

public class GetListCustomerHandle : IRequestHandler<GetListCustomer, CustomerPagingResult>
{
    public Task<CustomerPagingResult> Handle(GetListCustomer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}