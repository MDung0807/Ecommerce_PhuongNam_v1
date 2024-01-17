using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Review.Commands;

public class CreateReview : FormCreateReview, IRequest<bool>
{
    
}

public class CreateReviewHandle : IRequestHandler<CreateReview, bool>
{
    private readonly IReviewService _service;
    private readonly ICurrentUserService _currentUserService;

    public CreateReviewHandle(IReviewService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<bool> Handle(CreateReview request, CancellationToken cancellationToken)
    {
        request.CustomerId = new Guid(_currentUserService.IdUser);
        return await _service.Create(request);
    }
}