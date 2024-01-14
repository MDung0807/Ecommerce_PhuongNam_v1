using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;

public class GetFilterPaymentRequest : PaymentMethodPaging
{
    public string Name { get; set; }
}