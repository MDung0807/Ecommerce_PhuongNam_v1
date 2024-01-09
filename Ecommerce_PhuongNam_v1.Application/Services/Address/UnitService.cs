using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using Ecommerce_PhuongNam_v1.Application.Specifications.Address;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services.Address;

public class UnitService : IUnitService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<AdministrativeUnit, long> _repository;
    private readonly IMapper _mapper;

    #endregion

    public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<AdministrativeUnit, long>();
        _mapper = mapper;
    }
    
    #region -- Public Method --

    public async Task<UnitResponse> GetById(int id)
    {
        UnitSpecification unitSpecification = new UnitSpecification(id);
        AdministrativeUnit unit = await _repository.Get(unitSpecification, checkStatus: false);
        UnitResponse response = new UnitResponse();
        response = _mapper.Map<UnitResponse>(unit);
        return response;
    }

    public async Task<List<UnitResponse>> GetAll()
    {
        UnitSpecification unitSpecification = new UnitSpecification();
        List<AdministrativeUnit> units = await _repository.ToList(unitSpecification);
        return await AppUtils.MapObject<AdministrativeUnit, UnitResponse>(units, _mapper);
    }

    public Task<bool> Update(UnitUpdate entity, int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(UnitCreate entity, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsActive(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(int id)
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

    public Task<object> GetAll(object pagingRequest, int idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UnitResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    #endregion
}