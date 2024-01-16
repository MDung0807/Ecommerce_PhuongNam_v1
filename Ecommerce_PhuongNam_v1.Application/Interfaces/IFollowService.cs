using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.Paging.Follow;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IFollowService
{
    Task<bool> AddFollow(FollowRequest request);

    Task<bool> RemoveFollow(FollowRequest request);

    Task<FollowPagingResult> GetFollow(FollowPaging paging, Guid customerId);
}