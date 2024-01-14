using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using Ecommerce_PhuongNam_v1.Application.Specifications.Payment;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class PaymentMethodService : IPaymentMethodService
{

    private readonly IGenericRepository<PaymentMethod, Guid> _repository;
    private readonly IMapper _mapper;

    public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = unitOfWork.GenericRepository<PaymentMethod, Guid>();
        _mapper = mapper;
    }
    #region -- Public Method --

    public async Task<PaymentResponse> GetById(Guid id)
    {
        PaymentMethodSpec spec = new PaymentMethodSpec(id: id);
        PaymentMethod paymentMethod = await _repository.Get(specification: spec);
        return _mapper.Map<PaymentResponse>(paymentMethod);
    }

    public Task<List<PaymentResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(FormUpdatePayment entity)
    {
        PaymentMethodSpec spec = new PaymentMethodSpec(id: entity.Id);
        PaymentMethod paymentMethod = await _repository.Get(specification: spec);
        paymentMethod.Name = entity.Name;
        await _repository.Update(paymentMethod);
        return true;

    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(FormCreatePayment entity)
    {
        PaymentMethod paymentMethod = _mapper.Map<PaymentMethod>(entity);
        paymentMethod.Status = (int)EnumsApp.Active;
        await _repository.Create(paymentMethod);
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

    public Task<PaymentMethodPagingResult> GetAllByAdmin(PaymentMethodPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentMethodPagingResult> GetAll(PaymentMethodPaging pagingRequest)
    {
        PaymentMethodSpec spec = new PaymentMethodSpec(paging: pagingRequest);
        List<PaymentMethod> paymentMethods = await _repository.ToList(spec);
        int count = await _repository.Count(new PaymentMethodSpec());
        return AppUtils.ResultPaging<PaymentMethodPagingResult, PaymentResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<PaymentMethod, PaymentResponse>(paymentMethods, _mapper));
    }

    public Task<PaymentMethodPagingResult> GetAll(PaymentMethodPaging pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentMethodPagingResult> GetFilter(GetFilterPaymentRequest request)
    {
        PaymentMethodSpec spec = new PaymentMethodSpec(name: request.Name,
            paging: new PaymentMethodPaging { PageIndex = request.PageIndex, PageSize = request.PageSize });

        List<PaymentMethod> paymentMethods = await _repository.ToList(spec);
        int count = await _repository.Count(new PaymentMethodSpec(name: request.Name));

        return AppUtils.ResultPaging<PaymentMethodPagingResult, PaymentResponse>(
            index: request.PageIndex,
            size: request.PageSize,
            count: count,
            items: await AppUtils.MapObject<PaymentMethod, PaymentResponse>(paymentMethods, _mapper));
    }

    #endregion
}