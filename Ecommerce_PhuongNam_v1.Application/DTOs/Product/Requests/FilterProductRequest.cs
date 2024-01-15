using Ecommerce_PhuongNam_v1.Application.Paging.Product;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;

public class FilterProductRequest : ProductPaging
{
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public decimal StartAmount { get; set; }
    public decimal EndAmount { get; set; }
    public string Location { get; set; }
}