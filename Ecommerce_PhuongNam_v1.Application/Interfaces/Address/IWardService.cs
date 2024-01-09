using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Ward;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces.Address;

public interface IWardService : IService<WardCreate, WardUpdate, int, WardResponse, object, object>
{
    Task<Ward> WardGet(int id);
}