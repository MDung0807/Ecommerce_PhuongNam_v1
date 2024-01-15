using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Cart.Commands;

public class UpdateCart : FormUpdateCart, IRequest<bool>
{
    
}

public class UpdateCartHandle : IRequestHandler<UpdateCart, bool>
{
    private readonly ICartService _service;
    public UpdateCartHandle(ICartService service) => _service = service;
    
    public async Task<bool> Handle(UpdateCart request, CancellationToken cancellationToken)
    {
        return await _service.UpdateItem(request);
    }
}