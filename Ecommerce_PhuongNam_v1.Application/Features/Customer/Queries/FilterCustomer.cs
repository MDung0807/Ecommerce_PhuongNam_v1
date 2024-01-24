using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;

public class FilterCustomer : FilterCustomerRequest, IRequest<CustomerPagingResult>
{
}

public class FilterCustomerHandle : IRequestHandler<FilterCustomer, CustomerPagingResult>
{
    
    private readonly ICustomerService _service;

    public FilterCustomerHandle(ICustomerService service)
    {
        _service = service;
    }
    public async Task<CustomerPagingResult> Handle(FilterCustomer request, CancellationToken cancellationToken)
    {
        return await _service.FilterCustomer(request);
    }
}