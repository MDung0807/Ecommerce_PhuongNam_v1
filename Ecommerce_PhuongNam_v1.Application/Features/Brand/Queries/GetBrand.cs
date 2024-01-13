using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;

public class GetBrand : IRequest<BrandResponse>
{
    public Guid Id { get; set; }
    public GetBrand(Guid id) => Id = id;
}

public class GetBrandHandle : IRequestHandler<GetBrand, BrandResponse>
{
    private readonly IBrandService _service;

    public GetBrandHandle(IBrandService service) => _service = service;

    public async Task<BrandResponse> Handle(GetBrand request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}