using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using Ecommerce_PhuongNam_v1.Application.Specifications.Address;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services.Address;

public class ProvinceService : IProvinceService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Province, long> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    public ProvinceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Province, long>();
    }
    public async Task<ProvinceResponse> GetById(long id)
    {
        ProvinceSpecification provinceSpecification = new ProvinceSpecification(id);
        Province province = await _repository.Get(provinceSpecification, checkStatus: false);
        ProvinceResponse response = new ProvinceResponse();
        response = _mapper.Map<ProvinceResponse>(province);
        return response;
    }

    public async Task<List<ProvinceResponse>> GetAll()
    {
        ProvinceSpecification provinceSpecification = new ProvinceSpecification();
        List<Province> provinces = await _repository.ToList(provinceSpecification);
        List<ProvinceResponse> responses = await AppUtils.MapObject<Province, ProvinceResponse>(provinces, _mapper);
        return responses;
    }

    public Task<bool> Update(ProvinceUpdate entity, long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(ProvinceCreate entity, long userId)
    {
        throw new NotImplementedException();
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

    public Task<List<ProvinceResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }
}