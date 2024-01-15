using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Queries;

public class FilterProduct : FilterProductRequest, IRequest<ProductPagingResult>
{
    
}

public class FilterProductHandle : IRequestHandler<FilterProduct, ProductPagingResult>
{
    private readonly IProductService _service;
    public FilterProductHandle(IProductService service) => _service = service;
    public async Task<ProductPagingResult> Handle(FilterProduct request, CancellationToken cancellationToken)
    {
        return await _service.Filter(request);
    }
}