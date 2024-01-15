using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IProductService : IService<FormCreateProduct, FormUpdateProduct, Guid, ProductResponse, ProductPaging, ProductPagingResult>
{
    Task<ProductPagingResult> Filter(FilterProductRequest request);
    new Task<ProductDetail> GetById(Guid id);
}