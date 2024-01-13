using Ecommerce_PhuongNam_v1.Application.Paging.Brand;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Brand;

public sealed class BrandSpecification : BaseSpecification<Domain.Entities.Brand>
{
    public BrandSpecification(Guid id = default, string name = default, bool checkStatus = true, bool getIsChange = false, BrandPaging paging = null)
    :base (x => 
        (id == default || x.Id == id) &&
        (name == default || x.Name.Contains(name)), checkStatus)
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