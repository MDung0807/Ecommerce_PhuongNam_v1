using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IPaymentMethodService : IService<FormCreatePayment, FormUpdatePayment, Guid, PaymentResponse, PaymentMethodPaging, PaymentMethodPagingResult>
{
    Task<PaymentMethodPagingResult> GetFilter(GetFilterPaymentRequest request);
}