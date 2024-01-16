using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Follow.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Follow.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Follow;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Follow;

[Route("api/follows")]
[ApiController]
public class FollowController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FollowController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region  Controller

    [HttpPost("addFollow")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> AddFollow([FromBody] FollowRequest request)
    {
        var status = await _sender.Send(_mapper.Map<AddFollow>(request));
        return Ok(new Response<object>(!status, ""));
    }
    
    [HttpDelete("removeFollow")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> RemoveFollow([FromBody] FollowRequest request)
    {
        var status = await _sender.Send(_mapper.Map<RemoveFollow>(request));
        return Ok(new Response<object>(!status, ""));
    }

    [HttpGet("getFollow")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> GetFollow([FromQuery] FollowPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetFollow>(paging));
        return Ok(new Response<object>(false, response));
    }
    #endregion
}