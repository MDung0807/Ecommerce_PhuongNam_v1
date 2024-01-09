using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Address;

public sealed class ProvinceSpecification : BaseSpecification<Province>
{
    public ProvinceSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Districts);
        AddInclude(x => x.AdministrativeUnit);
        AddInclude(x => x.AdministrativeRegion);
    }
    
    public ProvinceSpecification() : base()
    {
        AddInclude(x => x.AdministrativeUnit);
        AddInclude(x => x.AdministrativeRegion);
    }
}