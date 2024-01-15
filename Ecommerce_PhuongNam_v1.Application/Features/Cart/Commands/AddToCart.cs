using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Cart.Commands;

public class AddToCart: FormAddCart, IRequest<bool>
{
    
}

public class AddToCartHandle : IRequestHandler<AddToCart, bool>
{
    private readonly ICartService _service;
    public async Task<bool> Handle(AddToCart request, CancellationToken cancellationToken)
    {
        return await _service.AddToCart(request);
    }
}