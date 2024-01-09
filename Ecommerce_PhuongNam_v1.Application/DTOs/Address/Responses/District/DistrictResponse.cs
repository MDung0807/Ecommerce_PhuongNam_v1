


using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;

public class DistrictResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<WardResponse> Wards { get; set; }
}