using BusBookTicket.Core.Models.Entity;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Auth : BaseEntity<Guid>
{
    public string IdDeceive { get; set; }
    public string Description { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiredAt { get; set; }
    public string Type { get; set; }
    public Account Account { get; set; }
}