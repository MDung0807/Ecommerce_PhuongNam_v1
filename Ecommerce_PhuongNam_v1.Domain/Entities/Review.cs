using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Review : BaseEntity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public int Like { get; set; }
    public int DisLike { get; set; }

    #region -- Relationship --
    public List<ReviewReply> Replies { get; set; }
    public Product Product { get; set; }
    public Customer Customer { get; set; }
    #endregion -- Relationship --
    
}