using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Cart;
using Ecommerce_PhuongNam_v1.Application.Specifications.Cart;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;


public class CartService : ICartService
{
    private readonly IGenericRepository<CartItem, Guid> _itemRepository;
    private readonly IGenericRepository<Cart, Guid> _repository;
    private readonly IMapper _mapper;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _itemRepository = unitOfWork.GenericRepository<CartItem, Guid>();
        _repository = unitOfWork.GenericRepository<Cart, Guid>();
    }
    public async Task<bool> AddToCart(FormAddCart request)
    {
        CartItemSpecification specification = new CartItemSpecification(variantId: request.VariantId, customerId:request.CustomerId);
        var cartItem = await _itemRepository.Get(specification);
        if (cartItem != null)
        {
            await UpdateItem(
                new FormUpdateCart
                {
                    Id = cartItem.Id,
                    VariantId = request.VariantId,
                    Quantity = cartItem.Quantity + request.Quantity,
                    CustomerId = request.CustomerId
                });
            return true;
        }

        cartItem = _mapper.Map<CartItem>(request);
        await _itemRepository.Create(cartItem);
        return true;
    }

    public async Task<bool> RemoveItem(Guid cartItemId)
    {
        CartItemSpecification specification = new CartItemSpecification(id:cartItemId);
        var item = await _itemRepository.Get(specification);
        await _itemRepository.DeleteHard(item);
        return true;
    }

    public async Task<bool> UpdateItem(FormUpdateCart request)
    {
        if (request.Quantity <= 0)
        {
            await RemoveItem(request.Id);
            return true;
        }
        CartItemSpecification specification = new CartItemSpecification(id:request.Id);
        var item = await _itemRepository.Get(specification);
        await _itemRepository.Update(item);
        return true;
    }

    public async Task<CartPagingResult> GetCart(CartPaging paging, Guid customerId)
    {
        CartItemSpecification specification = new CartItemSpecification(paging:paging, customerId:customerId);
        List<CartItem> items = await _itemRepository.ToList(specification);
        var itemResponses = await AppUtils.MapObject<CartItem, CartIItemResponse>(items, _mapper);
        var count = await _itemRepository.Count(new CartItemSpecification(customerId: customerId));
       
        return AppUtils.ResultPaging<CartPagingResult, CartIItemResponse>(
            index: paging.PageIndex,
            size: paging.PageSize,
            count: count,
            items: itemResponses);
    }
}