using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class RoleAccountService : IRoleAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<RoleAccount, Guid> _repository;

    public RoleAccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.GenericRepository<RoleAccount, Guid>();
    }
    public Task<object> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<object>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(object entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(object entity)
    {
        await _repository.Create((RoleAccount)entity);
        return true;
    }

    public Task<bool> ChangeIsActive(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistByParam(string param)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAllByAdmin(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }
}