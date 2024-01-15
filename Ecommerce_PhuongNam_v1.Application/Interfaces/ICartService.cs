using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Cart;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface ICartService
{
    Task<bool> AddToCart(FormAddCart request);
    Task<bool> RemoveItem(Guid cartItemId);
    Task<bool> UpdateItem(FormUpdateCart request);
    Task<CartPagingResult> GetCart(CartPaging paging,Guid customerId);
}