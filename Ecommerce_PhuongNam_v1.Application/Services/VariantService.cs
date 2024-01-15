using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class VariantService : IVariantService
{

    private readonly IGenericRepository<Variant, Guid> _repository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Specification, Guid> _specificationRepo;

    public VariantService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Variant, Guid>();
        _specificationRepo = unitOfWork.GenericRepository<Specification, Guid>();
    }
    
    #region -- Public Method --

    public Task<VariantResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<VariantResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(FormUpdateVariant entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(FormCreateVariant entity)
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

    public async Task<bool> CreateRange(List<Variant> variants)
    {
        foreach (var item in variants)
        {
            item.Status = (int)EnumsApp.Active;
        }
        return await _repository.CreateRange(variants);
    }

    #endregion
}