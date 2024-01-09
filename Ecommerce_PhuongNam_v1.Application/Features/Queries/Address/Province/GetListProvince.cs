using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.Province;

public class GetListProvince : IRequest<List<ProvinceResponse>>
{
}

public class GetProvincesHandle : IRequestHandler<GetListProvince, List<ProvinceResponse>>
{
    private readonly IProvinceService _service;
    public GetProvincesHandle(IProvinceService service) => _service = service;
    public async Task<List<ProvinceResponse>> Handle(GetListProvince request, CancellationToken cancellationToken)
    {
        return await _service.GetAll();
    }
}