using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Address
{
    public sealed class WardSpecification : BaseSpecification<Ward>
    {
        public WardSpecification(long id) : base(x => x.Id.Equals(id))
        {
            AddInclude(x => x.District);
            AddInclude(x => x.AdministrativeUnit);
            AddInclude(x => x.District.Province);
            AddInclude(x => x.District.Province.AdministrativeRegion);
        }
    }
}