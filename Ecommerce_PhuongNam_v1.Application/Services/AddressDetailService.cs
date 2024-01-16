using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Specifications.AddressDetail;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class AddressDetailService : IAddressDetailService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<AddressDetail, Guid> _repository;
    private readonly IMapper _mapper;
    private readonly IWardService _wardService;

    public AddressDetailService(IUnitOfWork unitOfWork, IMapper mapper, IWardService wardService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<AddressDetail, Guid>();
        _wardService = wardService;
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

    public async Task<bool> Delete(Guid id)
    {
        AddressDetailSpecification specification = new AddressDetailSpecification(id: id, getIsChange:true);
        var data = await _repository.Get(specification);
        await _repository.ChangeStatus(data, (int)EnumsApp.Delete);
        return true;
    }

    public async Task<bool> Create(object entity)
    {
        var data = (AddressDetail)entity;
        data.Status = (int)EnumsApp.Active;
        await _repository.Create(data);
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

    public async Task<object> GetAll(object pagingRequest, Guid idMaster)
    {
        AddressDetailSpecification specification = new AddressDetailSpecification(idParam: idMaster);
        var result = new List<LocationResponse>();
        var data = await _repository.ToList(specification);
        List<LocationResponse> locationResponses = new List<LocationResponse>();

        foreach (var item in data)
        {
            LocationResponse locationResponse = new LocationResponse();
            locationResponse.AddressResponse = _mapper.Map<AddressResponse>(item);
            locationResponse.Address = item.Address;
            locationResponse.IsPrimary = item.IsPrimary;
            locationResponse.Id = item.Id;

            locationResponses.Add(locationResponse);
        }

        return locationResponses;
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }
}