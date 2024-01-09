using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.District;

public class GetDistrict : IRequest<DistrictResponse>
{
    public long Id { get; set; }
    public GetDistrict(long id) => Id = id;
}

public class GetDistrictHandle: IRequestHandler<GetDistrict, DistrictResponse>
{
    private readonly IDistrictService _service;
    public GetDistrictHandle(IDistrictService service) => _service = service;
    public async Task<DistrictResponse> Handle(GetDistrict request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
} 