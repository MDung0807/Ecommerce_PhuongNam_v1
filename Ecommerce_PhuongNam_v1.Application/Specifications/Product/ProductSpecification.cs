using Ecommerce_PhuongNam_v1.Application.Paging.Product;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Product;

public sealed class ProductSpecification : BaseSpecification<Domain.Entities.Product>
{
    public ProductSpecification(Guid id = default, string location = default, string brandName = default,
        string categoryName = default, decimal startAmount = Decimal.MinValue, decimal endAmount = Decimal.MaxValue,
        bool checkStatus = true, bool getIsChange = false, ProductPaging paging = null, Guid shopId = default)
        : base(x =>
            (id == default || x.Id == id) &&
            (shopId == default || x.Shop.Id == shopId) &&
            (brandName == default || x.Brand.Name.Contains(brandName))&&
            (categoryName == default || x.Category.Name.Contains(categoryName)) &&
            (startAmount == Decimal.MinValue || x.Variants.Any(p => p.FinalPrice >= startAmount)) &&
            (endAmount == Decimal.MaxValue || x.Variants.Any(p => p.FinalPrice <= endAmount)))

{
        if (getIsChange)
        {
            AddInclude(x => x.Variants);
            AddInclude("Variants.Specifications");
            return;
        }

        if (paging != null)
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
        
        AddInclude(x => x.Brand);
        AddInclude(x => x.Category);
        AddInclude(x => x.Variants);
        AddInclude("Variants.Specifications");
        AddInclude(x => x.Reviews);
    }
}