using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Category.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Category.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;
using Ecommerce_PhuongNam_v1.Application.Validators.Category;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Category;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CategoryController(ISender sender, IMapper mapper)
    {
        _mapper = mapper;
        _sender = sender;
    }

    #region -- Controller --

    [HttpPost("create")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> Create([FromBody] FormCreateCategory request)
    {
        var validator = new FormCreateCateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException (result.Errors);
        }

        var status = await _sender.Send(_mapper.Map<CreateCategory>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }
    
    [HttpPut("update")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> Update([FromBody] FormUpdateCategory request)
    {
        var validator = new FormUpdateCateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException (result.Errors);
        }

        var status = await _sender.Send(_mapper.Map<UpdateCategory>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }
    
    
    [HttpPut("updateLogo")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> UpdateLogo([FromBody] FormUpdateLogoCategory request)
    {
        var status = await _sender.Send(_mapper.Map<UpdateLogoCategory>(request));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById([FromHeader] Guid id)
    {
        var response = await _sender.Send(new GetCategory(id));
        return Ok(new Response<CategoryResponse>(false, response));
    }

    [HttpGet("getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromHeader] CategoryPaging paging)
    {
        var response = await _sender.Send(_mapper.Map<GetListCategory>(paging));
        return Ok(new Response<CategoryPagingResult>(false, response));
    }
    
    [HttpGet("GetFilter")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFilter([FromHeader] FilterBrandRequest request)
    {
        var response = await _sender.Send(_mapper.Map<FilterCategory>(request));
        return Ok(new Response<CategoryPagingResult>(false, response));
    }
    #endregion
}