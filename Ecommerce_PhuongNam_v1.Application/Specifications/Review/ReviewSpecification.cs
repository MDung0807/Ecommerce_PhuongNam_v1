using Ecommerce_PhuongNam_v1.Application.Paging.Review;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Review;

public sealed class ReviewSpecification : BaseSpecification<Domain.Entities.Review>
{
    public ReviewSpecification(Guid id = default, Guid productId = default, bool checkStatus = true, bool getIsChange = false, ReviewPaging paging = null)
    :base (x => 
        (id == default || x.Id == id) &&
        (productId == default || x.Product.Id == productId),checkStatus)
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