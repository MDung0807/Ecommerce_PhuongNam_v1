using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Services;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class AuthOTP : OtpRequest, IRequest<bool>
{
}

public class AuthOTPHandle : IRequestHandler<AuthOTP, bool>
{
    private readonly ICustomerService _service;
    public AuthOTPHandle(ICustomerService service) => _service = service; 
    public async Task<bool> Handle(AuthOTP request, CancellationToken cancellationToken)
    {
        return await _service.AuthOtp(request);
    }
} 