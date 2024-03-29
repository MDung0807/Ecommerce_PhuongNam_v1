﻿using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Specifications.Address;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class RegionService : IRegionService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<AdministrativeRegion, long> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<AdministrativeRegion, long>();
    }

    #region -- Public Method --

    public async Task<RegionResponse> GetById(long id)
    {
        RegionSpecification regionSpecification = new RegionSpecification(id);
        AdministrativeRegion region = await _repository.Get(regionSpecification, checkStatus: false);
        RegionResponse response = new RegionResponse();
        response = _mapper.Map<RegionResponse>(region);
        return response;
    }

    public async Task<List<RegionResponse>> GetAll()
    {
        RegionSpecification regionSpecification = new RegionSpecification();
        List<AdministrativeRegion> regions = await _repository.ToList(regionSpecification);
        return await AppUtils.MapObject<AdministrativeRegion, RegionResponse>(regions, _mapper);
    }

    public Task<bool> Update(RegionUpdate entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(RegionCreate entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsActive(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(long id)
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

    public Task<List<RegionResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    #endregion
    
}