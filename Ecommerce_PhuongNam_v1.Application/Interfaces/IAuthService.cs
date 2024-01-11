using CloudinaryDotNet;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IAuthService : IService<object, object, Guid, object,object,object>
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<Account> GetAccountByUsername(string username, string roleName, bool checkStatus = true);
    Task<bool> ResetPass(FormResetPass request, Guid userId);
    // Task<bool> ChangeStatus(AuthRequest request);

    Task<AuthResponse> RefreshToken(RefreshTokenRequest request);
    Task<Account> GetAccountByUsername(string username, bool checkStatus = true);
}