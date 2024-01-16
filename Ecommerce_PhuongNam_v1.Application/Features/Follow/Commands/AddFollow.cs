using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Follow.Commands;

public class AddFollow : FollowRequest, IRequest<bool>
{
    
}

public class AddFollowHandle : IRequestHandler<AddFollow, bool >
{
    private readonly IFollowService _service;

    public AddFollowHandle(IFollowService service) => _service = service;
    public async Task<bool> Handle(AddFollow request, CancellationToken cancellationToken)
    {
        return await _service.AddFollow(request);
    }
}