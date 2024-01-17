using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Order;
using Ecommerce_PhuongNam_v1.Application.Specifications.Order;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order, Guid> _repository;
    private readonly IGenericRepository<OrderItem, Guid> _itemRepository;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Order, Guid>();
        _itemRepository = unitOfWork.GenericRepository<OrderItem, Guid>();

    }
    public async Task<OrderResponse> GetById(Guid id)
    {
        OrderSpecification specification = new OrderSpecification(id);
        var data = await _repository.Get(specification);
        return _mapper.Map<OrderResponse>(data);
    }

    public Task<List<OrderResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(FormCreateOrder entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Guid id)
    {
        OrderSpecification specification = new OrderSpecification(id: id, getIsChange: true);
        var data = await _repository.Get(specification);
        return await _repository.ChangeStatus(data, (int)EnumsApp.Delete);
    }

    public async Task<bool> Create(FormCreateOrder entity)
    {
        var data = _mapper.Map<Order>(entity);
        data.Status = (int)EnumsApp.Active;
        data = await _repository.Create(data);
        var totalAmount = 0;
        foreach (var orderItem in data.OrderItems)
        {
            orderItem.TotalAmount = orderItem.Quantity * orderItem.UnitPrice;
            totalAmount += orderItem.TotalAmount;
            orderItem.Status = (int)EnumsApp.Active;
        }
        data.TotalAmount = totalAmount;
        await _repository.Update(data);
        await _itemRepository.CreateRange(data.OrderItems.ToList());
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

    public Task<OrderPagingResult> GetAllByAdmin(OrderPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<OrderPagingResult> GetAll(OrderPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderPagingResult> GetAll(OrderPaging pagingRequest, Guid idMaster)
    {
        OrderSpecification specification = new OrderSpecification(customerId: idMaster, paging: pagingRequest);
        var data = await _repository.ToList(specification);
        var count = await _repository.Count(new OrderSpecification(customerId: idMaster));
        return AppUtils.ResultPaging<OrderPagingResult, OrderResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Order, OrderResponse>(data, _mapper));
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }
}