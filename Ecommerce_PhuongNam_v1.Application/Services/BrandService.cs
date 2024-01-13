using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class BrandService : IBrandService
{
    public Task<BrandResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BrandResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(FormUpdate entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(FormCreate entity)
    {
        throw new NotImplementedException();
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

    public Task<BrandPagingResult> GetAll(BrandPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<BrandPagingResult> GetAll(BrandPaging pagingRequest, Guid idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateLogo(UpdateLogo request)
    {
        throw new NotImplementedException();
    }
}