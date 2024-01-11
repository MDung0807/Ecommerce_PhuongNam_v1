using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Auth.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Auth.Queries;
using Ecommerce_PhuongNam_v1.Application.Specifications.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_PhuongNam_v1.API.Controllers.Auh;

public class AuthControllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthController  : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public AuthController(IMapper mapper, ISender sender)
        {
            _sender = sender;
            _mapper = mapper;
        }
        #region -- Controller --

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var validator = new AuthRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors);
            }
            request.RoleName = AppConstants.CUSTOMER;
            
            // await _authService.ChangeStatus(request);
            //var attemt = HttpContext.Session.GetInt32("FailLogin") ?? 0;
            var response = await _sender.Send(_mapper.Map<Login>(request));
            return Ok(new Response<AuthResponse>(false, response));
        }
        
        [HttpPost("shops/login")]
        public async Task<IActionResult> CompanyLogin([FromBody] AuthRequest request)
        {
            var validator = new AuthRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors);
            }
            request.RoleName = AppConstants.SHOP;
            var response = await _sender.Send(_mapper.Map<Login>(request));
            return Ok(new Response<AuthResponse>(false, response));
        }
        
        [HttpPost("admin/login")]
        public async Task<IActionResult> AdminLogin([FromBody] AuthRequest request)
        {
            var validator = new AuthRequestValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors);
            }
            request.RoleName = AppConstants.ADMIN;
            var response = await _sender.Send(_mapper.Map<Login>(request));
            return Ok(new Response<AuthResponse>(false, response));
        }
        
        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] FormResetPass request)
        {
            var validator = new FormResetPassValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors);
            }

            bool response = await _sender.Send(_mapper.Map<ResetPassword>(request));
            return Ok(new Response<string>(false, "response"));
        }
        
        [HttpPost("refreshToken")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {                   
            AuthResponse response = new AuthResponse();
            response = await _sender.Send(_mapper.Map<RefreshToken>(request));
            return Ok(new Response<AuthResponse>(false, response));
        } 
        #endregion -- Controller --
    }
}
