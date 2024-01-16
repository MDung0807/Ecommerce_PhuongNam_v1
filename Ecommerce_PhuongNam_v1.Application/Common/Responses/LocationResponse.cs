using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses;

namespace Ecommerce_PhuongNam_v1.Application.Common.Responses;

public class LocationResponse
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public bool IsPrimary { get; set; }
    public AddressResponse AddressResponse { get; set; }
}