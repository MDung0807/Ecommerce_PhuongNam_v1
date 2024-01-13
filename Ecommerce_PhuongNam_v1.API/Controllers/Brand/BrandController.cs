using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;
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
    public async Task<IActionResult> CreateBrand([FromBody] FormCreate request)
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
    
    [HttpPost("update")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> UpdateBrand([FromBody] FormUpdate request)
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
    #endregion -- Controller --
}