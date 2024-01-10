using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces
{
    public interface IAccountService : IService<AuthRequest, FormResetPass, Guid, AuthResponse, object, object>
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<Account> GetAccountByUsername(string username, string roleName, bool checkStatus = true);
        Task<bool> ResetPass(FormResetPass request);
        // Task<bool> ChangeStatus(AuthRequest request);

        Task<AuthResponse> RefreshToken(RefreshTokenRequest request);
        Task<Account> GetAccountByUsername(string username, bool checkStatus = true);
    }
}
