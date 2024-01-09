

using Ecommerce_PhuongNam_v1.Application.Specifications;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam.Address.Address.Application.Specification;

public sealed class DistrictSpecification : BaseSpecification<District>
{
    public DistrictSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Wards);
        AddInclude(x => x.Province);
        AddInclude(x => x.Province.AdministrativeUnit);
        AddInclude(x => x.Province.AdministrativeRegion);

    }
    
    public DistrictSpecification(int id, int idProvince) : base(x => x.Province.Id.Equals(id))
    {
        AddInclude(x => x.Province);
        AddInclude(x => x.AdministrativeUnit);
    }
}