using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;
using Ecommerce_PhuongNam_v1.Application.Specifications.Product;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class ProductService : IProductService
{

    private readonly IMapper _mapper;
    private readonly IGenericRepository<Product, Guid> _repository;
    private readonly IVariantService _variantService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IVariantService variantService)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<Product, Guid>();
        _unitOfWork = unitOfWork;
        _variantService = variantService;

    }
    public async Task<ProductResponse> GetById(Guid id)
    {
        var specification = new ProductSpecification(id: id);
        var product = await _repository.Get(specification: specification);
        return _mapper.Map<ProductResponse>(product);
    }

     async Task<ProductDetail> IProductService.GetById(Guid id)
    {
        var specification = new ProductSpecification(id: id);
        var product = await _repository.Get(specification: specification);
        return _mapper.Map<ProductDetail>(product);
    }

    public Task<List<ProductResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(FormUpdateProduct entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Guid id)
    {
        ProductSpecification specification = new ProductSpecification(id: id, getIsChange: true);
        var product = await _repository.Get(specification);
        return await _repository.ChangeStatus(product, (int)EnumsApp.Delete);
    }

    public async Task<bool> Create(FormCreateProduct entity)
    {
        try
        {
            await _unitOfWork.BeginTransaction();
            var product = _mapper.Map<Product>(entity);
            product = await _repository.Create(product);

            await _variantService.CreateRange(product.Variants.ToList());
            await _unitOfWork.SaveChangesAsync();

        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Console.WriteLine(e);
            throw new ExceptionDetail(AppConstants.ERROR);
        }

        return true;
    }

    public async Task<bool> ChangeIsActive(Guid id)
    {
        ProductSpecification specification = new ProductSpecification(id: id, getIsChange: true);
        var product = await _repository.Get(specification);
        return await _repository.ChangeStatus(product, (int)EnumsApp.Active);
    }

    public Task<bool> ChangeIsLock(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ChangeToDisable(Guid id)
    {
        ProductSpecification specification = new ProductSpecification(id: id, getIsChange: true);
        var product = await _repository.Get(specification);
        return await _repository.ChangeStatus(product, (int)EnumsApp.Disable);
    }

    public Task<bool> CheckToExistById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistByParam(string param)
    {
        throw new NotImplementedException();
    }

    public Task<ProductPagingResult> GetAllByAdmin(ProductPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ProductPagingResult> GetAll(ProductPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductPagingResult> GetAll(ProductPaging pagingRequest, Guid idMaster)
    {
        var specification = new ProductSpecification(shopId: idMaster, paging: pagingRequest);
        var count = await _repository.Count(new ProductSpecification(shopId: idMaster));
        var products = await _repository.ToList(specification);
        return AppUtils.ResultPaging<ProductPagingResult, ProductResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count:count,
            items: await AppUtils.MapObject<Product, ProductResponse>(products, _mapper));
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductPagingResult> Filter(FilterProductRequest request)
    {
        ProductSpecification specification = new ProductSpecification(
            brandName: request.BrandName, categoryName: request.CategoryName, location: request.Location,
            startAmount: request.StartAmount, endAmount: request.EndAmount, paging:new ProductPaging{PageIndex = request.PageIndex, PageSize = request.PageSize});

        int count = await _repository.Count(new ProductSpecification(
            brandName: request.BrandName, categoryName: request.CategoryName, location: request.Location,
            startAmount: request.StartAmount, endAmount: request.EndAmount));
        var products = await _repository.ToList(specification);
        return AppUtils.ResultPaging<ProductPagingResult, ProductResponse>(
            index: request.PageIndex,
            size: request.PageSize,
            count:count,
            items: await AppUtils.MapObject<Product, ProductResponse>(products, _mapper));
    }
    
}