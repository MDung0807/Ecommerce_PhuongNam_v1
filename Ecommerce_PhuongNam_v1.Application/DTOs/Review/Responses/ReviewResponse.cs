namespace Ecommerce_PhuongNam_v1.Application.DTOs.Review.Responses;

public class ReviewResponse
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public int Like { get; set; }
    public int DisLike { get; set; }

    public List<ReviewReplyResponse> Replies { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
}