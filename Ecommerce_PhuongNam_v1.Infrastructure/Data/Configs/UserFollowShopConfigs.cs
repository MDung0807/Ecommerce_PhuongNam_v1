using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class UserFollowShopConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<UserFollowShop>
{
    public void Configure(EntityTypeBuilder<UserFollowShop> builder)
    {
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.UserFollowShops)
            .HasForeignKey("CustomerId");

        builder.HasOne(x => x.Shop)
            .WithMany(x => x.UserFollowShops)
            .HasForeignKey("ShopId");

    }
}