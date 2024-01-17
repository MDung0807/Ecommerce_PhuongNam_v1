using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IOrderItemService : IService<OrderItemRequest, OrderItemRequest, Guid, OrderItemResponse, object, object>
{
    Task<bool> CreateRange(List<OrderItem> request);
}