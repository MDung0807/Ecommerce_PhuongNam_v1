using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Follow;
using Ecommerce_PhuongNam_v1.Application.Specifications.Follow;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class FollowService : IFollowService
{
    private readonly IGenericRepository<UserFollowShop, Guid> _repository;
    private readonly IMapper _mapper;

    public FollowService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<UserFollowShop, Guid>();
    }

    #region -- Public Method --

    public async Task<bool> AddFollow(FollowRequest request)
    {
        UserFollowShop userFollowShop = _mapper.Map<UserFollowShop>(request);
        userFollowShop.Status = (int)EnumsApp.Active;
        await _repository.Create(userFollowShop);
        return true;
    }

    public async Task<bool> RemoveFollow(FollowRequest request)
    {
        FollowSpecification specification = new FollowSpecification(customerId: request.CustomerId, shopId: request.ShopId);
        var data = await _repository.Get(specification: specification);
        await _repository.DeleteHard(data);
        return true;
    }

    public async Task<FollowPagingResult> GetFollow(FollowPaging paging, Guid customerId)
    {
        FollowSpecification specification = new FollowSpecification(paging: paging, customerId: customerId);
        var datas = await _repository.ToList(specification: specification);
        var count = await _repository.Count(new FollowSpecification(customerId: customerId));
        return AppUtils.ResultPaging<FollowPagingResult, FollowResponse>(
            index: paging.PageIndex,
            size: paging.PageSize,
            count: count,
            items: await AppUtils.MapObject<UserFollowShop, FollowResponse>(datas, _mapper));
    }

    #endregion
}