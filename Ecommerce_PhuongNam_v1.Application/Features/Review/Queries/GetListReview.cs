using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Review;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Review.Queries;

public class GetListReview : ReviewPaging, IRequest<ReviewPagingResult>
{
    public Guid ProductId { get; set; }
}

public class GetListReviewHandle: IRequestHandler<GetListReview, ReviewPagingResult>
{
    private readonly IReviewService _service;
    private readonly ICurrentUserService _currentUserService;

    public GetListReviewHandle(IReviewService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    
    public async Task<ReviewPagingResult> Handle(GetListReview request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request, request.ProductId);
    }
}