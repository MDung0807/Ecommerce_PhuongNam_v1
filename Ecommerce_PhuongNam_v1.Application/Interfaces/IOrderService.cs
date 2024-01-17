using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Order;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IOrderService : IService<FormCreateOrder, FormCreateOrder, Guid, OrderResponse, OrderPaging, OrderPagingResult>
{
    
}