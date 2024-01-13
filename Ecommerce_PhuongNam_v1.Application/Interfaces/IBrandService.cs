using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IBrandService : IService<FormCreate, FormUpdate, Guid, BrandResponse,BrandPaging, BrandPagingResult>
{
    Task<bool> UpdateLogo(UpdateLogo request);
}