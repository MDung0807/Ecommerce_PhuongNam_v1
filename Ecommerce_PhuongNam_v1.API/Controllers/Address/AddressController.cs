using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.District;
using Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.Province;
using Ecommerce_PhuongNam_v1.Application.Features.Queries.Address.Ward;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Address;

[ApiController]
[Route("api/")]
public class AddressController : ControllerBase
{
    #region -- Properties --

    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly IRegionService _regionService;
    private readonly IUnitService _unitService;

    #endregion -- Properties --

    public AddressController(
        ISender sender,
        ICurrentUserService currentUserService,
        IRegionService regionService
        , IUnitService unitService
        , IWardService wardService
    )
    {
        _sender = sender;
        _regionService = regionService;
        _unitService = unitService;
    }

    #region -- Controller --

    #region -- Region --

    [HttpGet("regions/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetRegionById([FromQuery] int id)
    {
        RegionResponse response = await _regionService.GetById(id);
        return Ok(new Response<RegionResponse>(false, response));
    }

    #endregion -- Region

    #region -- Unit --
    [HttpGet("units/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUnitById([FromQuery] int id)
    {
        UnitResponse response = await _unitService.GetById(id);
        return Ok(new Response<UnitResponse>(false, response));
    }
    #endregion -- Unit --

    #region -- Province --

    [HttpGet("provinces/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProvinceById([FromQuery] long id)
    {
        var response = await _sender.Send(new GetProvince(id));
        return Ok(new Response<ProvinceResponse>(false, response));
    }
    
    [HttpGet("provinces/getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllProvinces()
    {
        var responses = await _sender.Send(new GetListProvince());
        return Ok(new Response<List<ProvinceResponse>>(false, responses));
    }
    

    #endregion -- Province --

    #region -- District --

    [HttpGet("districts/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetDistrictById([FromQuery] long id)
    {
        var response = await _sender.Send(new GetDistrict(id));
        return Ok(new Response<DistrictResponse>(false, response));
    }

    #endregion -- District --

    #region -- Ward --
    [HttpGet("wards/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetWardById([FromQuery] long id)
    {
        var response = await _sender.Send(new GetWard(id));
        return Ok(new Response<WardResponse>(false, response));
    }
    #endregion -- Ward --
    #endregion -- Controller --
}