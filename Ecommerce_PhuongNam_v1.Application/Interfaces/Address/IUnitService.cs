﻿using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces.Address;

public interface IUnitService : IService<UnitCreate, UnitUpdate, int, UnitResponse, object, object>
{
    
}