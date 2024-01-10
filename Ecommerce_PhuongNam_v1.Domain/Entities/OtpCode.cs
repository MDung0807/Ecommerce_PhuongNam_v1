using Ecommerce_PhuongNam_v1.Domain.Common;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class OtpCode : BaseEntity<Guid>
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Code { get; set; }
    public int UserId { get; set; }
}