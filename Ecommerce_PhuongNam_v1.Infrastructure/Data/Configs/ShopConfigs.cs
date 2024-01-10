using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class ShopConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.HasOne(x => x.Account)
            .WithOne(x => x.Shop)
            .HasForeignKey<Shop>("AccountId");
    }
}