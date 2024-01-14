using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Queries;

public class GetPayment : IRequest<PaymentResponse>
{
    public Guid Id { get; set; }
}

public class GetPaymentHandle : IRequestHandler<GetPayment, PaymentResponse>
{
    private readonly IPaymentMethodService _service;
    public GetPaymentHandle(IPaymentMethodService service) => _service = service;
    public async Task<PaymentResponse> Handle(GetPayment request, CancellationToken cancellationToken)
    {
        return await _service.GetById(request.Id);
    }
}