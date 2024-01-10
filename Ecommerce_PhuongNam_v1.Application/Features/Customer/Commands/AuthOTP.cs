using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class AuthOTP : OtpRequest, IRequest<bool>
{
}

public class AuthOTPHandle : IRequestHandler<AuthOTP, bool>
{
    public Task<bool> Handle(AuthOTP request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
} 