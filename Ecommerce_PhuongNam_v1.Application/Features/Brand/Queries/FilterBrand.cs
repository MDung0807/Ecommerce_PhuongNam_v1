using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;

public class FilterBrand : FilterBrandRequest, IRequest<BrandPagingResult>
{
    
}

public class FilterBrandHandle : IRequestHandler<FilterBrand, BrandPagingResult>
{
    private readonly IBrandService _service;
    public FilterBrandHandle(IBrandService service) => _service = service;
    
    public async Task<BrandPagingResult> Handle(FilterBrand request, CancellationToken cancellationToken)
    {
        return await _service.GetFilterBrand(request);
    }
}