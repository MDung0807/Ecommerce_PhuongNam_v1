using Ecommerce_PhuongNam_v1.Application.Paging.Shop;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Shop;

public sealed class ShopSpecification: BaseSpecification<Domain.Entities.Shop>
{
    public ShopSpecification(Guid id = default, string name = default, string location = default,
        bool checkStatus = true, bool getIsChange = false, bool isMall = false, ShopPaging paging = null)
    :base(x => (id == default || x.Id == id)
    && (name == default || x.Name.Contains(name)) 
    && (isMall == false || x.IsMall == isMall)
    && (location == default ||
        x.AddressDetails.Any(l => l.Ward.FullName.Contains(location))
        || x.AddressDetails.Any(l => l.Ward.District.FullName.Contains(location))
        || x.AddressDetails.Any(l => l.Ward.District.Province.FullName.Contains(location))))
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