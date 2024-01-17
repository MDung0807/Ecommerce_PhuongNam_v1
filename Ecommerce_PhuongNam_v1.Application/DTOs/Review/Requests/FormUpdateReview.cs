namespace Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;

public class FormUpdateReview
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
}