using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces.Address;

public interface IProvinceService : IService<ProvinceCreate, ProvinceUpdate, long, ProvinceResponse, object, object>
{
    
}