using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Product;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private ISender _sender;
    private IMapper _mapper;

    public ProductController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region -- Controller --

    [HttpPost("create")]
    [AllowAnonymous]
    // [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> Create([FromBody] FormCreateProduct request)
    {
        var status = await _sender.Send(_mapper.Map<CreateProduct>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpPut("update")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> Update([FromBody] FormUpdateProduct request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateProduct>(request));
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var response = await _sender.Send(new GetProduct { Id = id });
        return Ok(new Response<object>(false, response));
    }

    [HttpGet("getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromHeader] FilterProductRequest request)
    {
        var response = await _sender.Send(_mapper.Map<FilterProduct>(request));
        return Ok(new Response<object>(false, response));
    }

    [HttpPut("changeIsActive")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> ChangeIsActive([FromHeader] Guid id)
    {
        var status = await _sender.Send(new ChangeIsActiveProduct { Id = id });
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }
    
    [HttpPut("changeIsDisable")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> ChangeIsDisable([FromHeader] Guid id)
    {
        var status = await _sender.Send(new ChangeIsDisableProduct() { Id = id });
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }
    
    [HttpPut("delete")]
    [Authorize(Roles = AppConstants.SHOP)]
    public async Task<IActionResult> Delete([FromHeader] Guid id)
    {
        var status = await _sender.Send(new DeleteProduct { Id = id });
        return Ok(new Response<object>(!status, AppConstants.SUCCESS));
    }
    #endregion
}