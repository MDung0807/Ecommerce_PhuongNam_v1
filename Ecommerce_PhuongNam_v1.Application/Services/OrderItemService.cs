using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Specifications.Order;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IGenericRepository<OrderItem, Guid> _repository;
    private readonly IMapper _mapper;

    public OrderItemService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<OrderItem, Guid>();
    }
    public Task<OrderItemResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderItemResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(OrderItemRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(OrderItemRequest entity)
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

    public async Task<object> GetAll(object pagingRequest, Guid idMaster)
    {
        OrderItemSpecification specification = new OrderItemSpecification(idMaster);
        var data = await _repository.ToList(specification);
        return data;
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateRange(List<OrderItem> request)
    {
        foreach (var item in request)
        {
            item.Status = (int)EnumsApp.Active;
        }
        return await _repository.CreateRange(request);
    }
}