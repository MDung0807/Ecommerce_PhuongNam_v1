using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.Common.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;
using Ecommerce_PhuongNam_v1.Application.Validators.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Customer;

[Route("api/Customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CustomerController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region -- Controllers --
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult>Register([FromBody] FormRegister register)
    {
        var validator = new FormRegisterValidator();
        var result = await validator.ValidateAsync(register);
        if (!result.IsValid)
        {
            throw new ValidatorException (result.Errors);
        }
        register.RoleName = AppConstants.CUSTOMER;
        var status = await _sender.Send(_mapper.Map<CreateCustomer>(register));
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }
    
    [HttpGet("profile")]
    [Authorize(Roles = "CUSTOMER")]
    public async Task<IActionResult> GetProfile()
    {
        var response = await _sender.Send(new GetCustomer());
        return Ok(new Response<ProfileResponse>(false, response));
    }

    [HttpGet("getById")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _sender.Send(new GetCustomer{Id = id});
        return Ok(new Response<object>(false, response));
    }

    [HttpGet("filter")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> FilterCustomer([FromQuery] FilterCustomerRequest request)
    {
        var response = await _sender.Send(_mapper.Map<FilterCustomer>(request));
        return Ok(new Response<CustomerPagingResult>(false, response));
    }
 
    [HttpGet("getAll")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetAllCustomer([FromQuery] CustomerPaging paging)
    {
        var response = await _sender.Send(new GetListCustomer());
        return Ok(new Response<CustomerPagingResult>(false, response));
    }

    [HttpPut("updateProfile")]
    [Authorize(Roles = "CUSTOMER")]
    public async Task<IActionResult> UpdateProfile([FromBody] FormUpdate request)
    {
        var validator = new FormUpdateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException(result.Errors);
        }
        int id = JwtUtils.GetUserID(HttpContext);
        var status = await _sender.Send(_mapper.Map<UpdateCustomer>(request));
        return Ok(new Response<string>(false, "response"));
    }

    [HttpPost("authOtp")]
    [AllowAnonymous]
    public async Task<IActionResult> AuthOtpCode([FromBody] OtpRequest request)
    {
        var status = await _sender.Send(_mapper.Map<AuthOTP>(request));
        return Ok(new Response<string>(!status, "response"));
    }

    [HttpPut("changeIsActive")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> ChangeIsActive([FromQuery] int customerId)
    {
        bool status = await _sender.Send(new ChangeIsActive());
        return Ok(new Response<string>(!status, "responses"));
    }
    
    [HttpPut("changeIsDelete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> ChangeIsDelete([FromQuery] int customerId)
    {
        bool status = await _sender.Send(new DeleteCustomer());
        return Ok(new Response<string>(!status, "responses"));
    }
    
    [HttpPut("ChangeIsLock")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> ChangIsLock([FromQuery] int customerId)
    {
        bool status = await _sender.Send(new ChangeIsLock());
        return Ok(new Response<string>(!status, "responses"));
    }

    [HttpPost("addLocation")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> AddLocation([FromBody] LocationRequest request)
    {
        var status = await _sender.Send(_mapper.Map<AddLocation>(request));
        return Ok(new Response<string>(!status, ""));
    }
    
    [HttpDelete("deleteLocation")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> DeleteLocation([FromQuery] Guid locationId)
    {
        var status = await _sender.Send(new RemoveLocation{Id = locationId});
        return Ok(new Response<string>(!status, ""));
    }
    
    [HttpGet("getLocation")]
    [Authorize(Roles = AppConstants.CUSTOMER)]
    public async Task<IActionResult> GetLocation()
    {
        var response = await _sender.Send(new Application.Features.Customer.Queries.GetLocation());
        return Ok(new Response<object>(false, response));
    }
    #endregion -- Controllers --
}