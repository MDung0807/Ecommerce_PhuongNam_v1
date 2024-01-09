using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Address;

public sealed class UnitSpecification : BaseSpecification<AdministrativeUnit>
{
    public UnitSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Provinces);
    }

    public UnitSpecification()
    {
        
    }
}