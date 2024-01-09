using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Address;

public sealed class RegionSpecification : BaseSpecification<AdministrativeRegion>
{
    public RegionSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Provinces);
    }

    public RegionSpecification()
    {
        
    }
}