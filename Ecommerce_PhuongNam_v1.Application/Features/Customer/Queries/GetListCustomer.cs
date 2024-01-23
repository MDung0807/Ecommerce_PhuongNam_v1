using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class GetListCustomer: CustomerPaging,IRequest<CustomerPagingResult>
{
    
}

public class GetListCustomerHandle : IRequestHandler<GetListCustomer, CustomerPagingResult>
{
    private readonly ICustomerService _service;

    public GetListCustomerHandle(ICustomerService service)
    {
        _service = service;
    }
    public async Task<CustomerPagingResult> Handle(GetListCustomer request, CancellationToken cancellationToken)
    {
        return await _service.GetAllCustomer(request);
    }
}