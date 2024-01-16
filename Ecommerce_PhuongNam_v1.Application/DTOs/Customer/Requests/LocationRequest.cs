namespace Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;

public class LocationRequest
{
    public string Location { get; set; }
    public long WardId { get; set; }
    public Guid CustomerId { get; set; }
    public bool IsPrimary { get; set; }
}