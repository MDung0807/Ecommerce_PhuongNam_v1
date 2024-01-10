namespace Ecommerce_PhuongNam_v1.Application.Specifications.Role;

public class RoleSpecification : BaseSpecification<Domain.Entities.Role>
{
    public RoleSpecification(string roleName) :base (x => x.Name == roleName){}
}