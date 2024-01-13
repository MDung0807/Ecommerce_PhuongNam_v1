using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Cloudinary;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using Ecommerce_PhuongNam_v1.Application.Specifications.Brand;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class BrandService : IBrandService
{

    private readonly IGenericRepository<Brand, Guid> _repository;
    private readonly IMapper _mapper;
    private readonly CloudImageService _imageService;

    public BrandService(IMapper mapper, IUnitOfWork unitOfWork, CloudImageService imageService)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Brand, Guid>();
        _imageService = imageService;
    }
    public async Task<BrandResponse> GetById(Guid id)
    {
        BrandSpecification specification = new BrandSpecification(id: id);
        Brand brand = await _repository.Get(specification);

        return _mapper.Map<BrandResponse>(brand);
    }

    public Task<List<BrandResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(FormUpdateBrand entity)
    {
        BrandSpecification specification = new BrandSpecification(id: entity.Id);
        Brand brand = await _repository.Get(specification) ?? throw new NotFoundException(AppConstants.NOT_FOUND);
        brand.Name = entity.Name;
        brand.Description = entity.Description;

        await _repository.Update(brand);
        return true;
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(FormCreateBrand entity)
    {
        Brand brand = _mapper.Map<Brand>(entity);
        brand.Status = (int)EnumsApp.Active;
        await _repository.Create(brand);
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

    public Task<BrandPagingResult> GetAllByAdmin(BrandPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BrandPagingResult> GetAll(BrandPaging pagingRequest)
    {
        BrandSpecification specification = new BrandSpecification(paging: pagingRequest);
        List<Brand> brands = await _repository.ToList(specification);
        int count = await _repository.Count(new BrandSpecification());
        var result = AppUtils.ResultPaging<BrandPagingResult, BrandResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Brand, BrandResponse>(brands, _mapper)
        );
        return result;
    }

    public Task<BrandPagingResult> GetAll(BrandPaging pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateLogo(FormUpdateLogoBrand request)
    {
        BrandSpecification specification = new BrandSpecification(id: request.Id);
        Brand brand = await _repository.Get(specification);
        string linkImage = await _imageService.SaveImage(request.Image);
        brand.Image = linkImage;
        await _repository.Update(brand);
        return true;
    }
}