using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;

public class UnitResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<ProvinceResponse> Provinces { get; set; }
}