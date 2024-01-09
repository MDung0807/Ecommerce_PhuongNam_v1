using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.Province;

public class GetProvince : IRequest<ProvinceResponse>
{
    public GetProvince(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}

public class GetProvinceHandle : IRequestHandler<GetProvince, ProvinceResponse>
{
    private readonly IProvinceService _service;
    public GetProvinceHandle(IProvinceService service) => _service = service;
    public async Task<ProvinceResponse> Handle(GetProvince request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}