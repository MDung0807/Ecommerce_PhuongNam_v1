using Ecommerce_PhuongNam_v1.Application.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class AddressDetail : IAddressDetail
{
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

    public Task<bool> Create(object entity)
    {
        throw new NotImplementedException();
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