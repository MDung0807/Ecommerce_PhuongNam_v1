using Ecommerce_PhuongNam_v1.Application.Paging.Brand;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;

public class FilterBrandRequest : BrandPaging
{
    public string Name { get; set; }
}