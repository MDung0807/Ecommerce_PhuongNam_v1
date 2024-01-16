namespace Ecommerce_PhuongNam_v1.Application.Specifications.AddressDetail;

public sealed class AddressDetailSpecification : BaseSpecification<Domain.Entities.AddressDetail>
{
    public AddressDetailSpecification(Guid id = default, Guid idParam = default, bool getIsChange = false)
    : base(x => 
        (id == default || x.Id == id) &&
        (idParam == default || (x.Shop.Id == idParam || x.Customer.Id == idParam)),
        checkStatus:true)
    {
        if (getIsChange)
        {
            return;
        }
        AddInclude(x => x.Customer);
        AddInclude(x => x.Shop);
        AddInclude(x => x.Ward);
        AddInclude(x => x.Ward.District);
        AddInclude(x => x.Ward.District.Province);  
    }
}