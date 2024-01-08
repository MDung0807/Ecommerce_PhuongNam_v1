using BusBookTicket.Core.Models.Entity;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class ReviewReply : BaseEntity<Guid>
{
    public string Content { get; set; }
    public string Image { get; set; }
    public int Like { get; set; }
    public int DisLike { get; set; }

    #region -- Relationship --
    public Customer Customer { get; set; }
    public long ParentId { get; set; }
    public Review Review { get; set; }
    public Shop Shop { get; set; }
    
    #endregion -- Relationship --
    

}