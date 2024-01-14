using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;
 
public class UpdateLogoShop : FormUpdateLogoShop, IRequest<bool>
{
    
}

public class UpdateLogoHandle : IRequestHandler<UpdateLogoShop, bool>
{
    private readonly IShopService _service;
    public UpdateLogoHandle(IShopService service) => _service = service;

    
    public async Task<bool> Handle(UpdateLogoShop request, CancellationToken cancellationToken)
    {
        return await _service.UpdateLogo(request);
    }
}