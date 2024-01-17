using AutoMapper;
using BusBookTicket.Core.Utils;
using CloudinaryDotNet.Actions;
using Ecommerce_PhuongNam_v1.Application.Common.Cloudinary;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Review;
using Ecommerce_PhuongNam_v1.Application.Specifications.Review;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IGenericRepository<Review, Guid> _repository;
    private readonly IMapper _mapper;
    private readonly CloudImageService _imageService;

    public ReviewService(IMapper mapper, IUnitOfWork unitOfWork, CloudImageService imageService)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Review, Guid>();
        _imageService = imageService;
    }
    public Task<ReviewResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReviewResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(FormUpdateReview entity)
    {
        ReviewSpecification specification = new ReviewSpecification(id:entity.Id);
        var data = await _repository.Get(specification);
        data.Content = entity.Content;
        data.Title = entity.Title;
        await _repository.Update(data);
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        ReviewSpecification specification = new ReviewSpecification(id:id);
        var data = await _repository.Get(specification);
        return await _repository.ChangeStatus(data, (int)EnumsApp.Delete);
    }

    public async Task<bool> Create(FormCreateReview entity)
    {
        Review review = _mapper.Map<Review>(entity);
        review.Status = (int)EnumsApp.Active;
        review.Image = await _imageService.SaveImage(entity.Image);
        await _repository.Create(review);
        return true;
    }

    public Task<bool> ChangeIsActive(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistByParam(string param)
    {
        throw new NotImplementedException();
    }

    public Task<ReviewPagingResult> GetAllByAdmin(ReviewPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ReviewPagingResult> GetAll(ReviewPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<ReviewPagingResult> GetAll(ReviewPaging pagingRequest, Guid idMaster)
    {
        ReviewSpecification specification = new ReviewSpecification(paging: pagingRequest, productId: idMaster);
        var data = await _repository.ToList(specification);
        var count = await _repository.Count(new ReviewSpecification(productId: idMaster));
        return AppUtils.ResultPaging<ReviewPagingResult, ReviewResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Review, ReviewResponse>(data, _mapper));
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }
}