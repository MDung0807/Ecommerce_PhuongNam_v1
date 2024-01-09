

using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using Ecommerce_PhuongNam_v1.Application.Paging;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Address.Address.Application.Specification;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services.Address;

public class DistrictService : IDistrictService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<District, long> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    public DistrictService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<District, long>();
    }

    #region -- Public Method --
    public async Task<DistrictResponse> GetById(long id)
    {
        DistrictSpecification districtSpecification = new DistrictSpecification(id);
        District district = await _repository.Get(districtSpecification, checkStatus: false);
        DistrictResponse response = new DistrictResponse();

        response = _mapper.Map<DistrictResponse>(district);
        return response;
    }

    public Task<List<DistrictResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(DistrictUpdate entity, long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(DistrictCreate entity, long userId)
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

    public Task<PagingResult<DistrictResponse>> GetAllByAdmin(PagingRequest pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<PagingResult<DistrictResponse>> GetAll(PagingRequest pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<PagingResult<DistrictResponse>> GetAll(PagingRequest pagingRequest, long idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<DistrictResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    #endregion -- Public Method --

    public Task<List<DistrictResponse>> GetDistrictByUnit(long provinceId)
    {
        throw new NotImplementedException();
    }
}