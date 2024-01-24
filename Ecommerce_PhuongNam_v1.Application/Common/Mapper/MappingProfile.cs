using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
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
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Follow.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Product.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Review.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Variant.Responses;
using Ecommerce_PhuongNam_v1.Application.Features.Auth.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Brand.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Cart.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Cart.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Category.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Category.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Customer.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Follow.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Follow.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Order.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Order.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.PaymentMethod.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Product.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Product.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Review.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Review.Queries;
using Ecommerce_PhuongNam_v1.Application.Features.Shop.Commands;
using Ecommerce_PhuongNam_v1.Application.Features.Shop.Queries;
using Ecommerce_PhuongNam_v1.Application.Paging.Brand;
using Ecommerce_PhuongNam_v1.Application.Paging.Cart;
using Ecommerce_PhuongNam_v1.Application.Paging.Category;
using Ecommerce_PhuongNam_v1.Application.Paging.Follow;
using Ecommerce_PhuongNam_v1.Application.Paging.Order;
using Ecommerce_PhuongNam_v1.Application.Paging.PaymentMethod;
using Ecommerce_PhuongNam_v1.Application.Paging.Product;
using Ecommerce_PhuongNam_v1.Application.Paging.Review;
using Ecommerce_PhuongNam_v1.Application.Paging.Shop;
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

        CreateMap<AddressDetail, AddressResponse>()
            .ForPath(dest => dest.WardId,
                opts => opts.MapFrom(x => x.Ward.Id))
            .ForPath(dest => dest.FullNameWard,
                opts => opts.MapFrom(x => x.Ward.FullName))
            .ForPath(dest => dest.DistrictId,
                opts => opts.MapFrom(x => x.Ward.District.Id))
            .ForPath(dest => dest.FullNameDistrict,
                opts => opts.MapFrom(x => x.Ward.District.FullName))
            .ForPath(dest => dest.ProvinceId,
                opts => opts.MapFrom(x => x.Ward.District.Province.Id))
            .ForPath(dest => dest.FullNameProvince,
                opts => opts.MapFrom(x => x.Ward.District.Province.FullName))
            ;
        CreateMap<AddressDetail, LocationResponse>()
            .ForPath(dest => dest.AddressResponse,
            opts=> opts.MapFrom(x => x));
        #endregion -- Address Module --

        #region -- Customer --

        CreateMap<FormRegister, CreateCustomer>();

        CreateMap<FormRegister, Customer>();
        CreateMap<FormUpdate, Customer>();
        CreateMap<FormUpdate, UpdateCustomer>();
        CreateMap<FilterCustomerRequest, FilterCustomer>();
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

        CreateMap<LocationRequest, AddressDetail>()
            .ForPath(dest => dest.Customer.Id, 
                opts => opts.MapFrom(x => x.CustomerId))
            .ForPath(dest => dest.Ward.Id,
                opts => opts.MapFrom(x => x.WardId));

        CreateMap<LocationRequest, AddLocation>();
        CreateMap<LocationResponse, CusLocationResponse>();

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
        CreateMap<BrandPaging, GetListBrand>();
        CreateMap<FilterBrandRequest, FilterBrand>();
        CreateMap<FormCreateBrand, Brand>();
        CreateMap<FormUpdateBrand, Brand>();

        #endregion

        #region -- Category --

        CreateMap<FormCreateCategory, CreateCategory>();
        CreateMap<FormUpdateCategory, UpdateCategory>();
        CreateMap<FormUpdateLogoCategory, UpdateLogoCategory>();
        CreateMap<CategoryPaging, GetListCategory>();
        CreateMap<FilterCategoryRequest, FilterCategory>();
        
        CreateMap<FormCreateCategory, Category>();
        CreateMap<FormUpdateCategory, Category>();
        CreateMap<Category, CategoryResponse>();

        #endregion

        #region -- PaymentMethod --

        CreateMap<FormCreatePayment, CreatePayment>();
        CreateMap<FormCreatePayment, PaymentMethod>();
        CreateMap<FormUpdatePayment, UpdatePayment>();
        CreateMap<FormUpdatePayment, PaymentMethod>();

        CreateMap<PaymentMethod, PaymentResponse>();
        CreateMap<PaymentMethodPaging, GetListPayment>();
        CreateMap<GetFilterPaymentRequest, GetFilterPayment >();

        #endregion

        #region -- Shop --

        CreateMap<FormCreateShop, Shop>();
        CreateMap<FormUpdateShop, Shop>();
        CreateMap<Shop, ShopResponse>();

        CreateMap<FormCreateShop, CreateShop>();
        CreateMap<FormUpdateShop, UpdateShop>();
        CreateMap<FormUpdateLogoShop, UpdateLogoShop>();
        CreateMap<FilterShopRequest, FilterShop>();
        CreateMap<ShopPaging, GetListShop>();

        #endregion

        #region -- Product --

        CreateMap<FormCreateProduct, Product>()
            .ForPath(dest => dest.Category.Id, 
                opts => opts.MapFrom(x => x.CategoryId))
            .ForPath(dest => dest.Brand.Id, 
                opts => opts.MapFrom(x => x.BrandId));
        CreateMap<FormUpdateProduct, Product>();
        CreateMap<FilterProductRequest, FilterProduct>();
        CreateMap<FormCreateProduct, CreateProduct>();
        CreateMap<FormUpdateProduct, UpdateProduct>();
        CreateMap<ProductPaging, GetAllProduct>();

        CreateMap<Product, ProductResponse>();
        CreateMap<Product, ProductDetail>();
        CreateMap<ProductImage, ProductImageResponse>();

        #endregion

        #region -- Variant --

        // CreateMap<FormCreateProduct, FormCreateVariant>()
        //     .ForPath(dest => dest,
        //         opts => opts.MapFrom(x => x.Variants));
        CreateMap<FormCreateVariant, Variant>();
        CreateMap<FormUpdateVariant, Variant>();
        CreateMap<FormSpecification, Specification>();
        CreateMap<Specification, FormSpecification>();
        CreateMap<Variant, VariantResponse>();

        #endregion

        #region -- Cart --

        CreateMap<FormAddCart, CartItem>()
            .ForPath(dest => dest.Cart.Customer.Id,
                opts => opts.MapFrom(x => x.CustomerId))
            .ForPath(dest => dest.Variant.Id, 
                opts => opts.MapFrom(x => x.VariantId));
        CreateMap<FormUpdateCart, CartItem>()
            .ForPath(dest => dest.Cart.Customer.Id,
                opts => opts.MapFrom(x => x.CustomerId))
            .ForPath(dest => dest.Variant.Id, 
                opts => opts.MapFrom(x => x.VariantId));;
        
        CreateMap<CartItem, CartIItemResponse>();

        CreateMap<FormAddCart, AddToCart>();
        CreateMap<FormUpdateCart, UpdateCart>();
        CreateMap<CartPaging, GetCart>();

        #endregion

        #region UserFollow Shop

        CreateMap<FollowRequest, UserFollowShop>()
            .ForPath(dest => dest.Customer.Id, 
                opts => opts.MapFrom(x => x.CustomerId))
            .ForPath(dest => dest.Shop.Id, 
                opts => opts.MapFrom(x => x.ShopId));

        CreateMap<UserFollowShop, FollowResponse>();

        CreateMap<FollowPaging, GetFollow>();
        CreateMap<FollowRequest, AddFollow>();
        CreateMap<FollowRequest, RemoveFollow>();

        #endregion

        #region -- Order --

        CreateMap<OrderItemRequest, OrderItem>()
            .ForPath(dest => dest.Variant.Id,
                opts => opts.MapFrom(x => x.VariantId));
        
        CreateMap<FormCreateOrder, Order>()
            .ForPath(dest => dest.PaymentMethod.Id, 
                opts => opts.MapFrom(x => x.PaymentMethodId))
            .ForPath(dest => dest.ToAddress.Id, 
                opts =>opts.MapFrom(x => x.ToAddressId))
            .ForPath(dest => dest.OrderItems, 
                opts => opts.MapFrom(x => x.ItemRequests))
            .ForPath(dest => dest.ShippingMethod, 
                opts => opts.MapFrom(x => x.ShippingMethodId));

        CreateMap<OrderItem, OrderItemResponse>();
        CreateMap<Order, OrderResponse>()
            .ForPath(dest => dest.ToAddress, 
                opts => opts.MapFrom(x => x.ToAddress))
            .ForPath(dest => dest.FromAddress,
                opts => opts.MapFrom(x => x.FromAddress))
            .ForPath(dest => dest.ItemResponses, 
                opts => opts.MapFrom(x => x.OrderItems));

        CreateMap<FormCreateOrder, CreateOrder>();
        CreateMap<OrderPaging, GetListOrder>();

        #endregion

        #region -- Review --

        CreateMap<FormCreateReview, Review>();
        CreateMap<FormUpdateReview, Review>();
        CreateMap<Review, ReviewResponse>();

        CreateMap<FormCreateReview, CreateReview>();
        CreateMap<FormUpdateReview, UpdateReview>();
        CreateMap<ReviewPaging, GetListReview>();

        #endregion
    }
}