namespace Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses;

public class AddressResponse
{
    public long WardId { get; set; }
    public string FullNameWard { get; set; }
    public long DistrictId { get; set; }
    public string FullNameDistrict { get; set; }
    public long ProvinceId { get; set; }
    public string FullNameProvince { get; set; }
}