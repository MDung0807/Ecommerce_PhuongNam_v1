using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;
using Ecommerce_PhuongNam_v1.Application.Specifications.Category;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Category, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<Category, Guid>();
    }

    #region -- Public Method --

    public async Task<CategoryResponse> GetById(Guid id)
    {
        CategorySpecification specification = new CategorySpecification(id: id);
        Category category = await _repository.Get(specification: specification);
        return _mapper.Map<CategoryResponse>(category);
    }

    public Task<List<CategoryResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(FormUpdateCategory entity)
    {
        try
        {
            CategorySpecification specification = new CategorySpecification(id: entity.Id);
            Category category = await _repository.Get(specification: specification);

            category.Name = entity.Name;
            category.Parent.Id = entity.ParentId;
            await _repository.Update(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(FormCreateCategory entity)
    {
        Category category = _mapper.Map<Category>(entity);
        category.Status = (int)EnumsApp.Active;
        Category categoryParent = new Category();
        if (!entity.ParentId.Equals(new Guid()))
        {
            CategorySpecification specification = new CategorySpecification(id: entity.ParentId);
            categoryParent = await _repository.Get(specification);
        }

        category.Parent = categoryParent;
        await _repository.Create(category);
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

    public Task<CategoryPagingResult> GetAllByAdmin(CategoryPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryPagingResult> GetAll(CategoryPaging pagingRequest)
    {
        CategorySpecification specification = new CategorySpecification(paging:pagingRequest);
        List<Category> categories = await _repository.ToList(specification);
        int count = await _repository.Count(new CategorySpecification());

        return AppUtils.ResultPaging<CategoryPagingResult, CategoryResponse>(
            index: pagingRequest.PageIndex,
            size: pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Category, CategoryResponse>(categories, _mapper));
    }

    public Task<CategoryPagingResult> GetAll(CategoryPaging pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateLogo(FormUpdateLogoCategory request)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryPagingResult> GetFilterCategory(FilterCategoryRequest request)
    {
        CategorySpecification specification = new CategorySpecification(name: request.Name, parentId: request.Parent,
            paging: new CategoryPaging{PageIndex = request.PageIndex, PageSize = request.PageSize});
        List<Category> categories = await _repository.ToList(specification);
        int count = await _repository.Count(new CategorySpecification(name: request.Name, parentId: request.Parent));

        return AppUtils.ResultPaging<CategoryPagingResult, CategoryResponse>(
            index: request.PageIndex,
            size: request.PageSize,
            count: count,
            items: await AppUtils.MapObject<Category, CategoryResponse>(categories, _mapper));
    }

    #endregion
}