using Ecommerce_PhuongNam_v1.Application.Paging.Category;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Category;

public sealed class CategorySpecification : BaseSpecification<Domain.Entities.Category>
{
    public CategorySpecification(Guid id = default, string name = default, bool checkStatus = true,
        bool getIsChange = false, CategoryPaging paging = null, Guid parentId = default)
    :base (x => 
        (id == default || x.Id == id) &&
        (name == default || x.Name.Contains(name)) &&
        (parentId == default || x.Parent.Id == parentId), checkStatus)
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