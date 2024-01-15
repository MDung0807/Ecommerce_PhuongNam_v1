using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Product.Queries;

public class GetProduct : IRequest<ProductDetail>
{
    public Guid Id { get; set; }
}

public class GetProductHandle: IRequestHandler<GetProduct, ProductDetail>
{
    private readonly IProductService _service;
    public GetProductHandle(IProductService service) => _service = service;
    public async Task<ProductDetail> Handle(GetProduct request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}