using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private Guid _idUser;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid IdUser => new Guid(_httpContextAccessor.HttpContext.ToString());
}