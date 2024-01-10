using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Specifications.Role;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Role, Guid> _repository;
        
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GenericRepository<Domain.Entities.Role, Guid>();
        }
        public async Task<Domain.Entities.Role> GetRole(string roleName)
        {
            RoleSpecification roleSpecification = new RoleSpecification(roleName);
            return await _repository.Get(roleSpecification);
        }
    }
}
