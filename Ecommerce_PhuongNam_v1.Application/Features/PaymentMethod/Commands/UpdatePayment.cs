using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Commands;

public class UpdatePayment : FormUpdatePayment, IRequest<bool>
{
    
}

public class UpdatePaymentHandle : IRequestHandler<UpdatePayment, bool>
{
    private readonly IPaymentMethodService _service;
    public UpdatePaymentHandle(IPaymentMethodService service) => _service = service;
    public async Task<bool> Handle(UpdatePayment request, CancellationToken cancellationToken)
    {
        return await _service.Update(request);
    }
}