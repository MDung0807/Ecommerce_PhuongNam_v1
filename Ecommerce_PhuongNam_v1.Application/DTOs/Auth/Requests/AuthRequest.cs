using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests
{
    [ValidateNever]
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string IdDeceive { get; set; }
    }
}
