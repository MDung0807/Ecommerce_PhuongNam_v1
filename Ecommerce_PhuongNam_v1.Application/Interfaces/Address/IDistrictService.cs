using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.Paging;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces.Address;

public interface IDistrictService : IService<DistrictCreate, DistrictUpdate, int, DistrictResponse, PagingRequest, PagingResult<DistrictResponse>>
{
}