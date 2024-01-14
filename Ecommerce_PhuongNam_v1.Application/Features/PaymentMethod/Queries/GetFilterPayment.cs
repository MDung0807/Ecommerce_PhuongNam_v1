using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Queries;

public class GetFilterPayment : GetFilterPaymentRequest, IRequest<PaymentMethodPagingResult>
{
    
}

public class GetFilterPaymentHandle: IRequestHandler<GetFilterPayment, PaymentMethodPagingResult>
{
    private readonly IPaymentMethodService _service;
    public GetFilterPaymentHandle(IPaymentMethodService service) => _service = service;
    public async Task<PaymentMethodPagingResult> Handle(GetFilterPayment request, CancellationToken cancellationToken)
    {
        return await _service.GetFilter(request);
    }
}