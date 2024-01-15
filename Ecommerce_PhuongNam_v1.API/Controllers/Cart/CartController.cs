using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Cart.Commands;
using Ecommerce_PhuongNam_v1.Application.Paging.Cart;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Cart;

[ApiController]
[Route("api/carts")]
public class CartController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CartController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region -- Controller --

    [HttpPost("addToCart")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> AddToCart([FromBody] FormAddCart request)
    {
        var status = await _sender.Send(_mapper.Map<AddToCart>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpPost("updateCart")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> UpdateCart([FromBody] FormUpdateCart request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateCart>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getCart")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> GetCart([FromQuery] CartPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<UpdateCart>(paging));
        return Ok(new Response<object>(false, response));
    }
    #endregion
}