using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Cloudinary;
using Ecommerce_PhuongNam_v1.Application.Common.MailKet.Service;
using Ecommerce_PhuongNam_v1.Application.Common.Mapper;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Services;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Services;
using Ecommerce_PhuongNam_v1.Application.Validators.Customer;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AddressDetail = Ecommerce_PhuongNam_v1.Application.Services.AddressDetail;

namespace Ecommerce_PhuongNam_v1.Application;

public static class DI
{
    public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
    }
    private static void AddServices(this IServiceCollection services)
    {
        #region -- Scoped --

        services.AddScoped<IRegionService, RegionService>()
            .AddScoped<IUnitService, UnitService>()
            .AddScoped<IProvinceService, ProvinceService>()
            .AddScoped<IDistrictService, DistrictService>()
            .AddScoped<IWardService, WardService>()
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAddressDetail, AddressDetail>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IRoleAccountService, RoleAccountService>()
            .AddScoped<IOtpService, OtpService>()
            .AddScoped<IMailService, MailService>()
            .AddScoped<IBrandService, BrandService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IPaymentMethodService, PaymentMethodService>()
            .AddScoped<IShopService, ShopService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IVariantService, VariantService>()
            .AddScoped<ICartService, CartService>()
            .AddScoped<IFollowService, FollowService>()
            .AddSingleton<CloudImageService>()
            ;
        #endregion -- Scoped --
        
        #region -- Config auto mapping --
        var mapperConfigs = new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile())
        );
        IMapper mapper = mapperConfigs.CreateMapper();
        services.AddSingleton(mapper);
        #endregion -- Config auto mapping --

        services.AddAuthorization();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DI).Assembly));
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

    } 
}