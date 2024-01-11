using Ecommerce_PhuongNam_v1.Domain.Common;

namespace Ecommerce_PhuongNam_v1.Domain.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        #region -- configs property --

        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        #endregion -- configs property --

        #region -- RelationShip--

        public Account Account { get; set; }
        public HashSet<Review> Reviews { get; set; }
        public Rank Rank { get; set; }
        public Cart Cart { get; set; }
        public HashSet<AddressDetail> AddressDetails { get; set; }
        public HashSet<Offer> Offers { get; set; }
        public HashSet<ReviewReply>Replies { get; set; }
        public HashSet<UserFollowShop> UserFollowShops { get; set; }
        #endregion -- RelationShip --
    }
}
