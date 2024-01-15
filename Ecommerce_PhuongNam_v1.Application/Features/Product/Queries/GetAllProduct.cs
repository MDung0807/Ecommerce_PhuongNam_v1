using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Queries;

public class GetAllProduct : ProductPaging, IRequest<ProductPagingResult>
{
    
}

public class GetAllHandle : IRequestHandler<GetAllProduct, ProductPagingResult>
{
    private readonly IProductService _service;
    private readonly ICurrentUserService _currentUserService;

    public GetAllHandle(IProductService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }
    public async Task<ProductPagingResult> Handle(GetAllProduct request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request, new Guid(_currentUserService.IdUser));
    }
}