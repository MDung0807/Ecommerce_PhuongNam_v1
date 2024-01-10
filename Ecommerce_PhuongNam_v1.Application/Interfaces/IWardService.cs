using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Ward;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IWardService : IService<WardCreate, WardUpdate, long, WardResponse, object, object>
{
    Task<Ward> WardGet(long id);
}