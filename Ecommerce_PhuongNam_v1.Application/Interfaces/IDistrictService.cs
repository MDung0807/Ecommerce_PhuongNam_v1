﻿using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.Paging;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IDistrictService : IService<DistrictCreate, DistrictUpdate, long, DistrictResponse, PagingRequest, PagingResult<DistrictResponse>>
{
}