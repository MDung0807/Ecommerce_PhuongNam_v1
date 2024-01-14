using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Queries;

public class GetListPayment : PaymentMethodPaging, IRequest<PaymentMethodPagingResult>
{
    
}

public class GetListPaymentHandle: IRequestHandler<GetListPayment, PaymentMethodPagingResult>
{
    private readonly IPaymentMethodService _service;
    public GetListPaymentHandle(IPaymentMethodService service) => _service = service;
    public async Task<PaymentMethodPagingResult> Handle(GetListPayment request, CancellationToken cancellationToken)
    {
        return await _service.GetAll(request);
    }
}