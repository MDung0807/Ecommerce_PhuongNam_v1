using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;

public class FormCreateReview
{
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile Image { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
}