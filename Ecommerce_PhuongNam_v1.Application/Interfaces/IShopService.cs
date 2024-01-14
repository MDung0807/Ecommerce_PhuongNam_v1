using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IShopService : IService<FormCreateShop, FormUpdateShop, Guid, ShopResponse, ShopPaging, ShopPagingResult>
{
    /// <summary>
    /// Get Shop with filter
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ShopPagingResult> FilterShop(FilterShopRequest request);
    
    /// <summary>
    /// Update logo for Shop
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<bool> UpdateLogo(FormUpdateLogoShop request);
}