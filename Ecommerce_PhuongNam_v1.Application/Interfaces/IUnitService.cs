using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IUnitService : IService<UnitCreate, UnitUpdate, long, UnitResponse, object, object>
{
    
}