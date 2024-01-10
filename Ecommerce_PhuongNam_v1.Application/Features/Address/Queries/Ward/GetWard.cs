using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.Ward;

public class GetWard : IRequest<WardResponse>
{
    public long Id { get; set; }
    public GetWard(long id) => Id = id;
}

public class GetWardHandle : IRequestHandler<GetWard, WardResponse>
{
    private readonly IWardService _service;
    public GetWardHandle(IWardService service) => _service = service;
    public async Task<WardResponse> Handle(GetWard request, CancellationToken cancellationToken)
    {
       return await _service.GetById(request.Id);
    }
} 