using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;

public interface ICurrentUserService
{
    string IdUser { get; }
}