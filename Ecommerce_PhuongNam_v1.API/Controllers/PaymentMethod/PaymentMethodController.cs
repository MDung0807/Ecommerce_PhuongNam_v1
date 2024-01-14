using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.PaymentMethod;

[Route("api/paymentmethods")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PaymentMethodController(ISender sender, IMapper mapper)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost("create")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> Create([FromBody] FormCreatePayment request)
    {
        var status = await _sender.Send(_mapper.Map<CreatePayment>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }

    [HttpPut("update")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> Update([FromBody] FormUpdatePayment request)
    {
        var status = await _sender.Send(_mapper.Map < UpdatePayment>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById([FromHeader] Guid id)
    {
        var response = await _sender.Send(new GetPayment { Id = id });
        return Ok(new Response<object>(false, response));
    }
    
    [HttpGet("getALl")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromHeader] PaymentMethodPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetListPayment>(paging));
        return Ok(new Response<object>(false, response));
    }

    [HttpGet("filter")]
    [AllowAnonymous]
    public async Task<IActionResult> Filter([FromHeader] GetFilterPaymentRequest request)
    {
        var response = await _sender.Send(_mapper.Map<GetFilterPayment>(request));
        return Ok(new Response<object>(false, response));
    }
}