using Ecommerce_PhuongNam_v1.Application.Paging.Shop;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;

public class FilterShopRequest : ShopPaging
{
    public string Name { get; set; }
    public string Location { get; set; }
    public bool IsMall { get; set; }
}