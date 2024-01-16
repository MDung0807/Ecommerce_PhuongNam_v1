using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
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
    private readonly ICurrentUserService _currentUserService;

    public RemoveFollowHandle(IFollowService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(RemoveFollow request, CancellationToken cancellationToken)
    {
        request.CustomerId = new Guid(_currentUserService.IdUser);
        return await _service.RemoveFollow(request);
    }
}