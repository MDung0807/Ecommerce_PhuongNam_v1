using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using Ecommerce_PhuongNam_v1.Application.Validators.Brand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Brand;

[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public BrandController(ISender sender, IMapper mapper)
    {
        _mapper = mapper;
        _sender = sender;
    }

    #region -- Controller --

    [HttpPost("create")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> CreateBrand([FromBody] FormCreateBrand request)
    {
        var validator = new FormCreateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException (result.Errors);
        }

        var status = await _sender.Send(_mapper.Map<CreateBrand>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));

    } 
    
    [HttpPut("update")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> UpdateBrand([FromBody] FormUpdateBrand request)
    {
        var validator = new FormUpdateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException (result.Errors);
        }

        var status = await _sender.Send(_mapper.Map<UpdateBrand>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));

    } 
    
    [HttpPut("updateLogo")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> UpdateLogo([FromForm] FormUpdateLogoBrand request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateLogoBrand>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _sender.Send(new GetBrand(id));
        return Ok(new Response<BrandResponse>(false, response));
    }
    
    [HttpGet("getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll(BrandPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetListBrand>(paging));
        return Ok(new Response<BrandPagingResult>(false, response));
    }
    #endregion -- Controller --
}