using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Responses;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces;

public interface IVariantService : IService<FormCreateVariant, FormUpdateVariant, Guid, VariantResponse, object, object>
{
    Task<bool> CreateRange(List<Variant> variants);
}