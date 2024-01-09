using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Application.Interfaces.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Address;

[ApiController]
[Route("api/")]
public class AddressController : ControllerBase
{
    #region -- Properties --

    private readonly IRegionService _regionService;
    private readonly IUnitService _unitService;
    private readonly IProvinceService _provinceService;
    private readonly IDistrictService _districtService;
    private readonly IWardService _wardService;

    #endregion -- Properties --

    public AddressController(
        IRegionService regionService
        , IUnitService unitService
        , IProvinceService provinceService
        , IDistrictService districtService
        , IWardService wardService
    )
    {
        _regionService = regionService;
        _unitService = unitService;
        _provinceService = provinceService;
        _districtService = districtService;
        _wardService = wardService;
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
    public async Task<IActionResult> GetProvinceById([FromQuery] int id)
    {
        ProvinceResponse response = await _provinceService.GetById(id);
        return Ok(new Response<ProvinceResponse>(false, response));
    }
    
    [HttpGet("provinces/getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllProvinces()
    {
        List<ProvinceResponse> responses = await _provinceService.GetAll();
        return Ok(new Response<List<ProvinceResponse>>(false, responses));
    }
    

    #endregion -- Province --

    #region -- District --

    [HttpGet("districts/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetDistrictById([FromQuery] int id)
    {
        DistrictResponse response = await _districtService.GetById(id);
        return Ok(new Response<DistrictResponse>(false, response));
    }

    #endregion -- District --

    #region -- Ward --
    [HttpGet("wards/getById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetWardById([FromQuery] int id)
    {
        WardResponse response = await _wardService.GetById(id);
        return Ok(new Response<WardResponse>(false, response));
    }
    #endregion -- Ward --
    #endregion -- Controller --
}