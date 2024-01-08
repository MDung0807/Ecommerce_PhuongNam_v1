using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Shop : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<ReviewReply> Replies { get; set; }
    public ICollection<AddressDetail> AddressDetails { get; set; }
    public ICollection<UserFollowShop> UserFollowShops { get; set; }
}