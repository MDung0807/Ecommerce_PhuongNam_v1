using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Review.Commands;

public class UpdateReview : FormUpdateReview, IRequest<bool>
{
    
}

public class UpdateReviewHandle : IRequestHandler<UpdateReview, bool>
{
    private readonly IReviewService _service;
    private readonly ICurrentUserService _currentUserService;

    public UpdateReviewHandle(IReviewService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<bool> Handle(UpdateReview request, CancellationToken cancellationToken)
    {
        request.CustomerId = new Guid(_currentUserService.IdUser);
        return await _service.Update(request);
    }
}