
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;

public class ProvinceResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<DistrictResponse> Districts { get; set; }
}