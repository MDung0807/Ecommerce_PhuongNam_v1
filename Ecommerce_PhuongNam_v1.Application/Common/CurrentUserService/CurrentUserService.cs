using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _idUser;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string IdUser => _httpContextAccessor.HttpContext!.User.Claims.ToList().First(c => c.Type == "UserID").Value;
}