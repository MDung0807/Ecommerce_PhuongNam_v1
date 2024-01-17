using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Review;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IReviewService : IService<FormCreateReview, FormUpdateReview, Guid, ReviewResponse, ReviewPaging, ReviewPagingResult>
{
    
}