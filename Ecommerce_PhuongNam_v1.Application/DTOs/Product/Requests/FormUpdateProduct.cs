﻿using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;

public class FormUpdateProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ShopId { get; set; }
    public List<FormCreateVariant> Variants { get; set; }
}