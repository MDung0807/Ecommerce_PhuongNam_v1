using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Follow;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Follow.Queries;

public class GetFollow : FollowPaging, IRequest<FollowPagingResult>
{
    
}

public class GetFollowHandle : IRequestHandler<GetFollow, FollowPagingResult>
{
    
    private readonly IFollowService _service;
    private readonly ICurrentUserService _currentUserService;

    public GetFollowHandle(IFollowService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    
    public async Task<FollowPagingResult> Handle(GetFollow request, CancellationToken cancellationToken)
    {
        return await _service.GetFollow(request, new Guid(_currentUserService.IdUser));
    }
}