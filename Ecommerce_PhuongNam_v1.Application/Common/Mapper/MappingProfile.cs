using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Requests.Ward;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.District;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Province;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Region;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Unit;
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses.Ward;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Auth.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Common.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region -- Address Module --

        CreateMap<RegionCreate, AdministrativeRegion>();
        CreateMap<RegionUpdate, AdministrativeRegion>();
        CreateMap<AdministrativeRegion, RegionResponse>();

        CreateMap<UnitCreate, AdministrativeUnit>();
        CreateMap<UnitUpdate, AdministrativeUnit>();
        CreateMap<AdministrativeUnit, UnitResponse>();

        CreateMap<ProvinceCreate, Province>();
        CreateMap<ProvinceUpdate, Province>();
        CreateMap<Province, ProvinceResponse>();

        CreateMap<DistrictCreate, District>();
        CreateMap<DistrictUpdate, District>();
        CreateMap<District, DistrictResponse>();

        CreateMap<WardCreate, Ward>();
        CreateMap<WardUpdate, Ward>();
        CreateMap<Ward, WardResponse>()
            .ForPath(dest => dest.District,
                opts => opts.MapFrom(x => x.District.FullName))
            .ForPath(dest => dest.DistrictId,
                opts => opts.MapFrom(x => x.District.Id))
            .ForPath(dest => dest.Province,
                opts => opts.MapFrom(x => x.District.Province.FullName))
            .ForPath(dest => dest.ProvinceId,
                opts => opts.MapFrom(x => x.District.Province.Id));

        CreateMap<WardResponse, AddressResponse>()
            .ForPath(dest => dest.WardId,
                opts => opts.MapFrom(x => x.Id))
            .ForPath(dest => dest.FullNameWard,
                opts => opts.MapFrom(x => x.FullName))
            .ForPath(dest => dest.DistrictId,
                opts => opts.MapFrom(x => x.DistrictId))
            .ForPath(dest => dest.FullNameDistrict,
                opts => opts.MapFrom(x => x.District))
            .ForPath(dest => dest.ProvinceId,
                opts => opts.MapFrom(x => x.ProvinceId))
            .ForPath(dest => dest.FullNameProvince,
                opts => opts.MapFrom(x => x.Province))
            ;
        #endregion -- Address Module --

        #region -- Customer --

        CreateMap<FormRegister, CreateCustomer>();

        CreateMap<FormRegister, Customer>();
        CreateMap<FormUpdate, Customer>();
        CreateMap<FormUpdate, UpdateCustomer>();
        CreateMap<Customer, ProfileResponse>()
            .ForPath(dest => dest.Username, 
                opt => opt.MapFrom(x => x.Account.Username))
            .ForPath(dest => dest.Rank,
                opt => opt.MapFrom(x => x.Rank.Name));
        CreateMap<Customer, CustomerResponse>()
            .ForPath(dest => dest.Username,
                opt => opt.MapFrom(x => x.Account.Username))
            .ForPath(dest => dest.Rank,
                opt => opt.MapFrom(x => x.Rank.Name));

        #endregion -- Customer --
        
        #region -- Configs Auth Module --
        CreateMap<FormRegister, AuthRequest>();
        CreateMap<AuthRequest, Account>();
        CreateMap<AuthRequest, Login>();
        CreateMap<Account, AccResponse>();

        CreateMap<Account, AuthResponse>();
        // CreateMap<FormRegisterCompany, AuthRequest>();
        #endregion -- Configs Auth Module --

        #region -- OTP Code --

        CreateMap<OtpRequest, AuthOTP>();
        CreateMap<OtpCode, OtpResponse>();
        #endregion

        #region -- Brand --

        CreateMap<FormCreateBrand, CreateBrand>();
        CreateMap<FormUpdateBrand, UpdateBrand>();
        CreateMap<FormUpdateLogoBrand, UpdateLogoBrand>();
        CreateMap<Brand, BrandResponse>();

        CreateMap<FormCreateBrand, Brand>();
        CreateMap<FormUpdateBrand, Brand>();

        #endregion

    }
}