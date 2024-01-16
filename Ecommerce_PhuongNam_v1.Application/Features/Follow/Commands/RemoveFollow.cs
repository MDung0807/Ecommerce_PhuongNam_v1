using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Follow.Commands;

public class RemoveFollow : FollowRequest, IRequest<bool>
{
    
}

public class RemoveFollowHandle : IRequestHandler<RemoveFollow, bool>
{
    private readonly IFollowService _service;

    public RemoveFollowHandle(IFollowService service) => _service = service;
    public async Task<bool> Handle(RemoveFollow request, CancellationToken cancellationToken)
    {
        return await _service.RemoveFollow(request);
    }
}