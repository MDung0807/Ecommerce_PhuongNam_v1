namespace Ecommerce_PhuongNam_v1.Application.Interfaces
{
    public interface IRoleService
    {
         Task<Domain.Entities.Role> GetRole(string roleName);
    }
}
