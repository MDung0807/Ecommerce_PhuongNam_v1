using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Review.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Review.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Review;

[ApiController]
[Route("api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ReviewController(IMapper mapper, ISender sender)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region Controller

    [Authorize(Roles = AppConstants.CUSTOMER)]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] FormCreateReview request)
    {
        var status = await _sender.Send(_mapper.Map<CreateReview>(request));
        return Ok(new Response<object>(!status, ""));
    }
    
    [Authorize(Roles = AppConstants.CUSTOMER)]
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] FormUpdateReview request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateReview>(request));
        return Ok(new Response<object>(!status, ""));
    }

    [HttpGet("inProduct")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllInProduct([FromQuery] Guid productId)
    {
        var response = await _sender.Send(new GetListReview { ProductId = productId });
        return Ok(new Response<object>(false, response));
    }
    #endregion
}