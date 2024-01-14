using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Cloudinary;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;
using Ecommerce_PhuongNam_v1.Application.Specifications.Shop;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class ShopService : IShopService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Shop, Guid> _repository;
    private readonly CloudImageService _imageService;
    private readonly IMapper _mapper;

    public ShopService(IUnitOfWork unitOfWork, IMapper mapper, CloudImageService imageService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<Shop, Guid>();
        _imageService = imageService;
    }
    #region -- Public Method --

    public async Task<ShopResponse> GetById(Guid id)
    {
        ShopSpecification specification = new ShopSpecification(id: id);
        Shop shop = await _repository.Get(specification: specification);

        return _mapper.Map<ShopResponse>(shop);
    }

    public Task<List<ShopResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(FormUpdateShop entity)
    {
        ShopSpecification specification = new ShopSpecification(id: entity.Id);
        Shop shop = await _repository.Get(specification: specification);
        shop.Name = entity.Name;
        shop.Email = entity.Email;
        shop.PhoneNumber = entity.PhoneNumber;

        await _repository.Update(shop);
        return true;
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(FormCreateShop entity)
    {
        Shop shop = _mapper.Map<Shop>(entity);
        await _repository.Create(shop);
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

    public Task<ShopPagingResult> GetAllByAdmin(ShopPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<ShopPagingResult> GetAll(ShopPaging pagingRequest)
    {
        var specification = new ShopSpecification(paging: pagingRequest);
        var shops = await _repository.ToList(specification);
        var count = await _repository.Count(new ShopSpecification());
        return AppUtils.ResultPaging<ShopPagingResult, ShopResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Shop, ShopResponse>(shops, _mapper));
    }

    public Task<ShopPagingResult> GetAll(ShopPaging pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ShopPagingResult> FilterShop(FilterShopRequest request)
    {
        ShopSpecification shopSpecification = new ShopSpecification(name: request.Name, location: request.Location,
            isMall: request.IsMall,
            paging: new ShopPaging { PageIndex = request.PageIndex, PageSize = request.PageSize });

        int count = await _repository.Count(new ShopSpecification(name: request.Name, location: request.Location,
            isMall: request.IsMall));
        List<Shop> shops = await _repository.ToList(shopSpecification);
        return AppUtils.ResultPaging<ShopPagingResult, ShopResponse>(
            index: request.PageIndex,
            size: request.PageSize,
            count: count,
            items: await AppUtils.MapObject<Shop, ShopResponse>(shops, _mapper));
    }

    public async Task<bool> UpdateLogo(FormUpdateLogoShop request)
    {
        try
        {
            ShopSpecification specification = new ShopSpecification(id: request.Id);
            Shop shop = await _repository.Get(specification: specification);
            shop.Logo = await _imageService.SaveImage(request.Logo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionDetail(AppConstants.ERROR);
        }

        return true;
    }

    #endregion
}