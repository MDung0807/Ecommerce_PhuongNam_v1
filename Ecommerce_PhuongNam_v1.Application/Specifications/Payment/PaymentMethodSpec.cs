using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Mailjet.Client.Resources;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Payment;

public sealed class PaymentMethodSpec : BaseSpecification<PaymentMethod>
{
    public PaymentMethodSpec(Guid id = default, string name = default, bool checkStatus = true,
        bool getIsChange = false, PaymentMethodPaging paging = null)
        : base(x => (id == default || x.Id == id)
         && (name == default || x.Name.Contains(name)), checkStatus)
    {
        if (getIsChange)
        {
            return;
        }

        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}