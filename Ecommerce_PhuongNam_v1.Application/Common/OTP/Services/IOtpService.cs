using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;

namespace Ecommerce_PhuongNam_v1.Application.Common.OTP.Services;

public interface IOtpService
{
    Task<OtpResponse> CreateOtp(OtpRequest request);
    Task<bool> AuthenticationOtp(OtpRequest request);
}