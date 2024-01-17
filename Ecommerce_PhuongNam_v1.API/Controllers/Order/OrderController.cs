using AutoMapper;
using CloudinaryDotNet.Actions;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Order.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Order.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Order;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{

    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public OrderController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("create")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> Create([FromBody] FormCreateOrder request)
    {
        var status = await _sender.Send(_mapper.Map<CreateOrder>(request));
        return Ok(new Response<object>(!status, ""));
    }
    
    [HttpDelete("cancel")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> Cancel([FromQuery]Guid id)
    {
        var status = await _sender.Send(new CancelOrder{Id = id});
        return Ok(new Response<object>(!status, ""));
    }

    [HttpGet("orderDetail")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var response = await _sender.Send(new GetOrder { Id = id });
        return Ok(new Response<object>(false, response));
    }
    
    [HttpGet("orders")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> GetAll([FromQuery] OrderPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetListOrder>(paging));
        return Ok(new Response<object>(false, response));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    }
}