using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Shop : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsMall { get; set; }
    public string Logo { get; set; }

    public Account Account { get; set; }
    public HashSet<Product> Products { get; set; }
    public HashSet<ReviewReply> Replies { get; set; }
    public HashSet<AddressDetail> AddressDetails { get; set; }
    public HashSet<UserFollowShop> UserFollowShops { get; set; }
}