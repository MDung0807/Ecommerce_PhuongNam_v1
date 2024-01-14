using System.Runtime.InteropServices;
using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Shop.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Shop;

[Route("api/shops")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ShopController(ISender sender, IMapper mapper)
    {
        _mapper = mapper;
        _sender = sender;
    }

    #region -- Controller --

    [HttpPost("create")]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] FormCreateShop request)
    {
        var status = await _sender.Send(_mapper.Map<CreateShop>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpPut("update")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> Update([FromBody] FormUpdateShop request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateShop>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }
    
    [HttpPut("updateLogo")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> UpdateLogo([FromForm] FormUpdateLogoShop request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateLogoShop>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getById")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> GetById([FromHeader] Guid id)
    {
        var response = await _sender.Send(new GetShop { Id = id });
        return Ok(new Response<object>(false, response));
    }

    [HttpGet("getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromHeader]ShopPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetListShop>(paging));
        return Ok(new Response<object>(false, response));
    }

    [HttpGet("filter")]
    [AllowAnonymous]
    public async Task<IActionResult> Filter([FromHeader] FilterShopRequest request)
    {
        var response = await _sender.Send(_mapper.Map<FilterShop>(request));
        return Ok(new Response<object>(false, response));
    }

    [HttpPut("changeIsActive")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> ChangeIsActive([FromHeader] Guid id)
    {
        var response = await _sender.Send(new ChangeIsShopActive { Id = id });
        return Ok(new Response<object>(false, response));
    }
    
    [HttpPut("Delete")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> Delete([FromHeader] Guid id)
    {
        var response = await _sender.Send(new ChangeIsShopDelete{ Id = id });
        return Ok(new Response<object>(false, response));
    }
    
    [HttpPut("changeIsWaiting")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> ChangeIsWaiting([FromHeader] Guid id)
    {
        var response = await _sender.Send(new ChangeIsShopWaiting { Id = id });
        return Ok(new Response<object>(false, response));
    }
    #endregion
}