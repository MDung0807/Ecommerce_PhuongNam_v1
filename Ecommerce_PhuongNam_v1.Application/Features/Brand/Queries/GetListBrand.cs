using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;

public class GetListBrand : BrandPaging, IRequest<BrandPagingResult>
{
    
}

public class GetListBrandHandle : IRequestHandler<GetListBrand, BrandPagingResult>
{
    private readonly IBrandService _service;

    public GetListBrandHandle(IBrandService service) => _service = service;
    public async Task<BrandPagingResult> Handle(GetListBrand request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request);
    }
}