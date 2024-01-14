using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Commands;

public class CreatePayment : FormCreatePayment, IRequest<bool>
{
    
}

public class CreatePaymentHandle : IRequestHandler<CreatePayment, bool>
{
    private readonly IPaymentMethodService _service;
    public CreatePaymentHandle(IPaymentMethodService service) => _service = service;
    public async Task<bool> Handle(CreatePayment request, CancellationToken cancellationToken)
    {
        return await _service.Create(request);
    }
}