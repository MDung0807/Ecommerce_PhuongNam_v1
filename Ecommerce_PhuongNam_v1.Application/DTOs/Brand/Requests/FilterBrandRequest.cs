using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;

public class FilterBrandRequest : BrandPaging
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}