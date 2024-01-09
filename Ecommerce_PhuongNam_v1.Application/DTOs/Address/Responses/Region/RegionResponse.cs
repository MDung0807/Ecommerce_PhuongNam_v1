
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;

public class RegionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProvinceResponse> Provinces { get; set; }
}