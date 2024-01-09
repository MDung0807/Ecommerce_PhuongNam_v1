using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Ward;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using Ecommerce_PhuongNam_v1.Application.Specifications.Address;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services.Address;

public class WardService : IWardService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Ward, long> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    #region -- Public method --

    public WardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<Ward, long>();
        _mapper = mapper;
    }
    public async Task<WardResponse> GetById(long id)
    {
        Ward ward = await WardGet(id);
        return _mapper.Map<WardResponse>(ward);
    }

    public Task<List<WardResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(WardUpdate entity, long id, long userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Update(ward);
        return true;
    }

    public async Task<bool> Delete(long id, long userId)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification, checkStatus: false);
        ward = ChangeStatus(ward, (int)EnumsApp.Delete);
        await _repository.Update(ward);
        return true;
    }

    public async Task<bool> Create(WardCreate entity, long userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Create(ward);
        return true;
    }

    public Task<bool> ChangeIsActive(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(long id)
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

    public Task<object> GetAll(object pagingRequest, long idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<WardResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    public async Task<Ward> WardGet(long id)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification);
        return ward;
    }

    #endregion -- Public method --

    #region -- Private Method --

    private Ward ChangeStatus(Ward entity, int status)
    {
        entity.Status = status;
        return entity;
    }
    #endregion -- Private Method --
}