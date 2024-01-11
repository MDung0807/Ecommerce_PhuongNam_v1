using BusBookTicket.Core.Models.EntityFW.Configurations;
using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class AppDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration<Account>(new AccountConfig());
        modelBuilder.ApplyConfiguration<AddressDetail>(new AddressDetailConfigs());
        modelBuilder.ApplyConfiguration<AdministrativeRegion>(new AdministrativeRegionConfigs());
        modelBuilder.ApplyConfiguration<AdministrativeUnit>(new AdministrativeUnitConfigs());
        modelBuilder.ApplyConfiguration<Auth>(new AuthConfigs());
        modelBuilder.ApplyConfiguration<Brand>(new BrandConfigs());
        modelBuilder.ApplyConfiguration<Cart>(new CartConfigs());
        modelBuilder.ApplyConfiguration<CartItem>(new CartItemConfigs());
        modelBuilder.ApplyConfiguration<Category>(new CategoryConfigs());
        modelBuilder.ApplyConfiguration<Customer>(new CustomerConfigs());
        modelBuilder.ApplyConfiguration<District>(new DistrictConfigs());
        modelBuilder.ApplyConfiguration<Offer>(new OfferConfigs());
        modelBuilder.ApplyConfiguration<Order>(new OrderConfigs());
        modelBuilder.ApplyConfiguration<OrderItem>(new OrderItemConfigs());
        modelBuilder.ApplyConfiguration<OtpCode>(new OtpCodeConfigs());
        modelBuilder.ApplyConfiguration<PaymentMethod>(new PaymentMethodConfigs());
        modelBuilder.ApplyConfiguration<Product>(new ProductConfigs());
        modelBuilder.ApplyConfiguration<ProductImage>(new ProductImageConfig());
        modelBuilder.ApplyConfiguration<Province>(new ProvinceConfigs());
        modelBuilder.ApplyConfiguration<Rank>(new RankConfigs());
        modelBuilder.ApplyConfiguration<Review>(new ReviewConfigs());
        modelBuilder.ApplyConfiguration<ReviewReply>(new ReviewReplyConfigs());
        modelBuilder.ApplyConfiguration<Role>(new RoleConfigs());
        modelBuilder.ApplyConfiguration<RoleAccount>(new RoleAccountConfigs());
        modelBuilder.ApplyConfiguration<Sale>(new SaleConfigs());
        modelBuilder.ApplyConfiguration<ShippingMethod>(new ShippingMethodConfigs());
        modelBuilder.ApplyConfiguration<Shop>(new ShopConfigs());
        modelBuilder.ApplyConfiguration<Specification>(new SpecificationConfigs());
        modelBuilder.ApplyConfiguration<UserFollowShop>(new UserFollowShopConfigs());
        modelBuilder.ApplyConfiguration<Ward>(new WardConfigs());

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (EntityEntry<BaseEntity<Guid>> entry in ChangeTracker.Entries<BaseEntity<Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreateBy = _currentUserService.IdUser;
                    entry.Entity.UpdateBy = _currentUserService.IdUser;
                    entry.Entity.DateCreate = DateTime.Now;
                    entry.Entity.DateUpdate = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Property(x => x.DateCreate).IsModified = false;
                    entry.Property(x => x.CreateBy).IsModified = false;
                    entry.Entity.DateUpdate = DateTime.Now;
                    entry.Entity.UpdateBy = _currentUserService.IdUser;
                    break;
            }
        }
        
        

        return base.SaveChangesAsync(cancellationToken);
                
    }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AddressDetail> AddressDetails { get; set; }
    public DbSet<AdministrativeRegion> AdministrativeRegions { get; set; }
    public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItem> OtpCodes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewReply> ReviewReplies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleAccount> RoleAccounts { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<UserFollowShop> UserFollowShops { get; set; }
    public DbSet<Ward> Wards { get; set; }
}