using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces.Address;

public interface IRegionService : IService<RegionCreate, RegionUpdate, int, RegionResponse, object, object>
{
    
}